using Microsoft.SqlServer.Server;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace API_FedEx_Quote
{
    public class StoredProcedure
    {
        private static string _token;
        private static DateTime _tokenExpiry;

        [Microsoft.SqlServer.Server.SqlProcedure(Name = "FedEx_Quote_Rates_20251108")]
        public static void ApiQuoteRateProcedure(string postAuthData, string postCredentialsData, string version, string cancelBy, string prnDallaCreate)
        {

        }

        private static void HandleErrorResponse(HttpWebResponse response)
        {
            SqlContext.Pipe.Send("Error: Response status code is " + response.StatusCode);
            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
            {
                string errorContent = reader.ReadToEnd();
                SqlContext.Pipe.Send("Error details: " + errorContent);
            }
        }

        private static async Task HandleWebException(WebException ex)
        {
            if (ex.Response is HttpWebResponse errorResponse)
            {
                DataTable errorsInfosData = new DataTable("errorsInfosData");
                AddErrorsDataColumns(errorsInfosData);

                SqlContext.Pipe.Send("Exception: " + errorResponse.StatusCode);

                try
                {
                    using (Stream responseStream = errorResponse.GetResponseStream())
                    {
                        Stream actualStream = responseStream;

                        // ?? Detect and handle gzip or deflate encoding
                        string encoding = errorResponse.ContentEncoding?.ToLowerInvariant();
                        if (!string.IsNullOrEmpty(encoding))
                        {
                            if (encoding.Contains("gzip"))
                                actualStream = new GZipStream(responseStream, CompressionMode.Decompress);
                            else if (encoding.Contains("deflate"))
                                actualStream = new DeflateStream(responseStream, CompressionMode.Decompress);
                        }

                        using (StreamReader reader = new StreamReader(actualStream))
                        {
                            string errorContent = await reader.ReadToEndAsync();
                            SqlContext.Pipe.Send("Error response content: " + errorContent);

                            try
                            {
                                var errorObj = JsonConvert.DeserializeObject<FedExRateResponse>(errorContent);
                                SendLongMessage("error obj " + errorObj);

                                if (errorObj != null)
                                {
                                    if (!string.IsNullOrEmpty(errorObj.TransactionId))
                                        SqlContext.Pipe.Send("TransactionId: " + errorObj.TransactionId);

                                    if (errorObj.Errors != null)
                                    {
                                        foreach (var err in errorObj.Errors)
                                        {
                                            var rowErrors = errorsInfosData.NewRow();
                                            rowErrors["TransactionId"] = errorObj.TransactionId;
                                            rowErrors["Code"] = err?.Code ?? (object)DBNull.Value;
                                            rowErrors["Message"] = err?.Message ?? (object)DBNull.Value;
                                            errorsInfosData.Rows.Add(rowErrors);
                                        }
                                    }
                                }
                            }
                            catch (Exception parseEx)
                            {
                                SqlContext.Pipe.Send("Failed to parse JSON error: " + parseEx.Message);
                            }
                        }
                    }
                }
                catch (Exception readEx)
                {
                    SqlContext.Pipe.Send("Failed to read error response: " + readEx.Message);
                }

                // Step 4: Insert Data into SQL Database
                try
                {
                    string connString = "Data Source=DESKTOP-6DFRDG6\\SQLEXPRESS;Initial Catalog=API_Ship_v2;User ID=sample;Password=sample;";

                    using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required,
                       new TransactionOptions
                       {
                           IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted, // Adjust based on your requirements
                           Timeout = TimeSpan.FromMinutes(5) // Set appropriate timeout
                       }))
                    {
                        using (SqlConnection connection = new SqlConnection(connString))
                        {
                            connection.Open();

                            using (SqlCommand cmd = new SqlCommand())
                            {
                                cmd.Connection = connection;
                                cmd.CommandType = CommandType.StoredProcedure;

                                // First Stored Procedure Execution
                                cmd.CommandText = "dbo.FedEx_PickUp_Create_Web_Errors_ImportData_20250401";
                                cmd.Parameters.Add(new SqlParameter
                                {
                                    ParameterName = "@DataToInsertPickUpCreateWebErrors",
                                    SqlDbType = SqlDbType.Structured,
                                    Value = errorsInfosData,
                                    TypeName = "dbo.fedEx_pickup_create_temp_web_errors"
                                });

                                cmd.ExecuteNonQuery();
                                cmd.Parameters.Clear(); // Clear parameters before reuse

                            }
                        }

                        // Complete the transaction
                        scope.Complete();
                    }

                }
                catch (Exception exc)
                {
                    SendLongMessage("Database Error: " + exc.Message);
                }

            }
            else
            {
                SqlContext.Pipe.Send("An unexpected error occurred: " + ex.Message);
            }
        }


        private static void HandleGeneralException(Exception ex)
        {
            SendLongMessage("Handled exception: " + ex.Message);
        }

        // Helper method to send messages in chunks
        private static void SendLongMessage(string message)
        {
            const int maxChunkSize = 4000;
            int messageLength = message.Length;
            for (int i = 0; i < messageLength; i += maxChunkSize)
            {
                string chunk = message.Substring(i, Math.Min(maxChunkSize, messageLength - i));
                SqlContext.Pipe.Send(chunk);
            }
        }

        // Helper method to check token expiration and retrieve a new token if necessary
        public static string GetTokenFedexFromFirstApi(string postData)
        {
            string APIUrl = "https://apis-sandbox.fedex.com/oauth/token";
            //string APIUrl = "https://apis.fedex.com/oauth/token";
            string tokenFedexCreated = string.Empty;

            try
            {
                // Return cached token if still valid
                if (!string.IsNullOrEmpty(_token) && DateTime.UtcNow < _tokenExpiry)
                {
                    return _token;
                }

                // Ensure TLS 1.2 or TLS 1.3 is used
                System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls13;

                // Configure HTTP request
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(APIUrl);
                request.Timeout = 30000; // 30 seconds timeout
                request.ReadWriteTimeout = 30000;
                request.ContentType = "application/x-www-form-urlencoded";
                request.Method = "POST";

                byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                using (Stream requestStream = request.GetRequestStream())
                {
                    requestStream.Write(byteArray, 0, byteArray.Length);
                }

                // Process HTTP response
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        using (Stream responseStream = response.GetResponseStream())
                        using (StreamReader reader = new StreamReader(responseStream))
                        {
                            string responseStr = reader.ReadToEnd();
                            var responseObject = JsonConvert.DeserializeObject<ResponseObjectToken>(responseStr);

                            _token = responseObject.access_token;
                            _tokenExpiry = DateTime.UtcNow.AddSeconds(responseObject.expires_in - 60);

                            SendLongMessage("token Created  ==>  " + _token);
                            return _token;
                        }
                    }
                    else
                    {
                        HandleErrorResponse(response);
                    }
                }
            }
            catch (WebException ex)
            {
                HandleWebException(ex);
            }
            catch (Exception ex)
            {
                HandleGeneralException(ex);
            }

            return tokenFedexCreated;
        }

        private static void AddErrorsDataColumns(DataTable errorDataTable)
        {
            // Define DataTable columns based on JSON structure
            // Adding columns with specified properties


            // Define the "IdKey" column as an auto-incrementing integer
            DataColumn idKeyColumn = new DataColumn("IdKey", typeof(int))
            {
                AutoIncrement = true,
                AutoIncrementSeed = 1, // Starting value for the identity
                AutoIncrementStep = 1  // Increment step
            };
            // Add the column to the DataTable
            errorDataTable.Columns.Add(idKeyColumn);

            errorDataTable.Columns.Add("TransactionId", typeof(string));
            errorDataTable.Columns.Add("Code", typeof(string));
            errorDataTable.Columns.Add("Message", typeof(string));
        }
    }
}
