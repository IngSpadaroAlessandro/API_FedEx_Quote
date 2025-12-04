using Microsoft.SqlServer.Server;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
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
        public static void ApiQuoteRateProcedure(SqlString jsonBody, string postAuthData)
        {
            string jsonBodyString = jsonBody.ToString();
            string bearerTokenFedex = string.Empty;
            // call of the first api for fedex token  generation
            try
            {

                //get the token that fedex generates by calling an api
                bearerTokenFedex = GetTokenFedexFromFirstApi(postAuthData);
                SendLongMessage("bearerTokenFedex  " + bearerTokenFedex);
            }
            catch (Exception ex)
            {
                SendLongMessage("error in GetTokenFedexFromFirstApi" + ex);
                HandleGeneralException(ex);
            }

            string APIUrl = "https://apis-sandbox.fedex.com/rate/v1/rates/quotes";
            //string APIUrl = "https://apis.fedex.com/pickup/v1/pickups";

            // Create all DataTables
            DataTable dtFedExRateResponse = FedExTableFactory.CreateDT_FedExRateResponse();
            DataTable dtRateReplyDetail = FedExTableFactory.CreateDT_RateReplyDetail();
            DataTable dtCustomerMessage = FedExTableFactory.CreateDT_CustomerMessage();
            DataTable dtRatedShipmentDetail = FedExTableFactory.CreateDT_RatedShipmentDetail();
            DataTable dtSurcharge = FedExTableFactory.CreateDT_Surcharge();
            DataTable dtRatedPackage = FedExTableFactory.CreateDT_RatedPackage();
            DataTable dtServiceName = FedExTableFactory.CreateDT_ServiceName();
            DataTable dtAlert= FedExTableFactory.CreateDT_Alert();

            try
            {
                // Log initial information
                SqlContext.Pipe.Send("sono arrivati questi dati:");
                SqlContext.Pipe.Send("------------------------------------------");
                SqlContext.Pipe.Send("jsonBody");
                //SqlContext.Pipe.Send(jsonBodyString);
                SqlContext.Pipe.Send("------------------------------------------");


                System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12 | System.Net.SecurityProtocolType.Tls13;
                WebPermission permission = new WebPermission(NetworkAccess.Connect, APIUrl);
                permission.AddPermission(NetworkAccess.Connect, APIUrl);
                permission.AddPermission(NetworkAccess.Accept, APIUrl);
                permission.Demand();

                IEnumerator myConnectEnum = permission.ConnectList;

                while (myConnectEnum.MoveNext())
                { }

                IEnumerator myAcceptEnum = permission.AcceptList;

                // Configure HTTP request
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(APIUrl);
                string requestBody = jsonBodyString;
                SqlContext.Pipe.Send("Popolo HTTP request");
                byte[] bytes;
                bytes = Encoding.ASCII.GetBytes(requestBody);


                request.ContentType = "application/json";
                request.Accept = "application/json";
                request.Method = "POST";
                request.Headers.Add("X-locale", "en_US");
                request.Headers.Add("Authorization", "Bearer " + bearerTokenFedex);
                request.AutomaticDecompression = DecompressionMethods.None;
                request.Headers.Remove(HttpRequestHeader.AcceptEncoding);
                //request.Headers.Add("x-customer-transaction-id", "BeT");// solo se si e in production

                //SetRequestHeaders(request);
                //SqlContext.Pipe.Send("request: " + request);

                // Prepare request body
                Stream requestStream = request.GetRequestStream();
                requestStream.Write(bytes, 0, bytes.Length);
                requestStream.Close();

                //SqlContext.Pipe.Send("requestBody: " + requestBody);
                // Process HTTP response
                HttpWebResponse response = null;
                try
                {
                    response = (HttpWebResponse)request.GetResponse();
                    //SqlContext.Pipe.Send("StatusCode: " + response.StatusCode);
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        SqlContext.Pipe.Send("StatusCode: " + response.StatusCode);
                        Stream responseStream = null;
                        string responseStr = "";
                        try
                        {
                            responseStream = response.GetResponseStream();
                            responseStr = new StreamReader(responseStream).ReadToEnd();
                        }
                        catch (Exception ex)
                        {
                            SqlContext.Pipe.Send("responseStream ex: " + ex);
                            HandleGeneralException(ex);
                            throw;
                        }

                        // Parse JSON response and populate trackingData
                        var jsonObject = JObject.Parse(responseStr);
                        //SendLongMessage("jsonObject: " + jsonObject);

                        // Convert back to JSON string
                        responseStr = jsonObject.ToString(Formatting.Indented);


                        // Deserialize the JSON into a dynamic object
                        var responseObject = JsonConvert.DeserializeObject<FedExRateResponse>(responseStr);
                        //SendLongMessage("responseObject: " + responseObject);

                        if (responseObject?.Output == null) return;

                        var trackingData = responseObject.Output;

                        // Fill FedExRateResponse table
                        FedExTableFactory.CreateRow_FedExRateResponse(dtFedExRateResponse, responseObject);

                        // CustomerMessages
                        if (trackingData != null)
                        {
                            foreach (var alert in trackingData.Alerts)
                            {
                                FedExTableFactory.CreateRow_Alert(dtAlert, alert, responseObject.CustomerTransactionId);

                            }
                        }

                        // Iterate RateReplyDetails
                        if (responseObject?.Output?.RateReplyDetails != null)
                        {
                            foreach (var rateReply in responseObject.Output.RateReplyDetails)
                            {
                                FedExTableFactory.CreateRow_RateReplyDetail(dtRateReplyDetail, rateReply, responseObject.CustomerTransactionId);

                                // CustomerMessages
                                if (rateReply?.CustomerMessages != null)
                                {
                                    foreach (var msg in rateReply.CustomerMessages)
                                    {
                                        FedExTableFactory.CreateRow_CustomerMessage(dtCustomerMessage, msg, responseObject.CustomerTransactionId);

                                    }
                                }

                                // RatedShipmentDetails
                                if (rateReply?.RatedShipmentDetails != null)
                                {
                                    foreach (var rsd in rateReply.RatedShipmentDetails)
                                    {
                                        FedExTableFactory.CreateRow_RatedShipmentDetail(dtRatedShipmentDetail, rsd, responseObject.CustomerTransactionId);


                                        // Surcharges from ShipmentRateDetail
                                        if (rsd?.ShipmentRateDetail?.SurCharges != null)
                                        {
                                            foreach (var surcharge in rsd.ShipmentRateDetail.SurCharges)
                                            {

                                                FedExTableFactory.CreateRow_Surcharge(dtSurcharge, surcharge, responseObject.CustomerTransactionId);

                                            }
                                        }

                                        // RatedPackages
                                        if (rsd?.RatedPackages != null)
                                        {
                                            foreach (var pkg in rsd.RatedPackages)
                                            {
                                                FedExTableFactory.CreateRow_RatedPackage(dtRatedPackage, pkg, responseObject.CustomerTransactionId);

                                                // Surcharges from PackageRateDetail
                                                if (pkg?.PackageRateDetail?.Surcharges != null)
                                                {
                                                    foreach (var surcharge in pkg.PackageRateDetail.Surcharges)
                                                    {
                                                        FedExTableFactory.CreateRow_Surcharge(dtSurcharge, surcharge, responseObject.CustomerTransactionId);
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }

                                // ServiceNames from ServiceDescription
                                if (rateReply?.ServiceDescription?.Names != null)
                                {
                                    foreach (var name in rateReply.ServiceDescription.Names)
                                    {
                                        FedExTableFactory.CreateRow_ServiceName(dtServiceName, name, responseObject.CustomerTransactionId);
                                    }
                                }
                            }
                        }



                    }
                    else
                    {
                        HandleErrorResponse(response);
                    }

                }
                catch (WebException ex)
                {
                    HandleWebException(ex);
                }
                finally
                {
                    response?.Close();
                }

                // Step 4: Insert Data into SQL Database
                try
                {
                    string connString = "Data Source=DESKTOP-6DFRDG6\\SQLEXPRESS;Initial Catalog=API_Ship_v2;User ID=sample;Password=sample;";
                    //string connString = "Data Source=localhost\\BETCLOUD;Initial Catalog=HUB_API_FORNITORI;User ID=sa;Password=Sa2020BeT";

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

                                SqlContext.Pipe.Send("Rows: " + dtFedExRateResponse.Rows.Count);
                                foreach (DataColumn col in dtFedExRateResponse.Columns)
                                    SqlContext.Pipe.Send(col.ColumnName);


                                // -------------------------
                                // Execute Main quote SP
                                // -------------------------
                                try
                                {
                                    SqlContext.Pipe.Send("Starting Fedex_Quote_RateResponse_ImportData_Main_20251108...");

                                    cmd.CommandText = "dbo.Fedex_Quote_RateResponse_ImportData_Main_20251108";
                                    cmd.Parameters.Add(new SqlParameter
                                    {
                                        ParameterName = "@DataToInsertMain",
                                        SqlDbType = SqlDbType.Structured,
                                        Value = dtFedExRateResponse,
                                        TypeName = "dbo.fedex_quote_rateresponse_temp"
                                    });

                                    SqlContext.Pipe.Send("Executing stored procedure…");

                                    cmd.ExecuteNonQuery();

                                    SqlContext.Pipe.Send("Stored procedure executed successfully.");
                                }
                                catch (SqlException ex)
                                {
                                    SqlContext.Pipe.Send("SQL ERROR occurred:");
                                    SqlContext.Pipe.Send("Message: " + ex.Message);
                                    SqlContext.Pipe.Send("Line: " + ex.LineNumber);
                                    SqlContext.Pipe.Send("Procedure: " + ex.Procedure);
                                    SqlContext.Pipe.Send("Error Number: " + ex.Number);

                                    // optionally rethrow
                                    // throw;
                                }
                                catch (Exception ex)
                                {
                                    SqlContext.Pipe.Send("GENERAL ERROR occurred:");
                                    SqlContext.Pipe.Send("Message: " + ex.Message);

                                    // optionally rethrow
                                    // throw;
                                }
                                finally
                                {
                                    cmd.Parameters.Clear();
                                    SqlContext.Pipe.Send("Parameters cleared.");
                                }

                                SqlContext.Pipe.Send($"Rows in DataTable: {dtFedExRateResponse.Rows.Count}");
                                foreach (DataRow row in dtFedExRateResponse.Rows)
                                {
                                    SqlContext.Pipe.Send($"Row TransactionId: {row["TransactionId"]}, QuoteDate: {row["QuoteDate"]}");
                                    SqlContext.Pipe.Send($"Row TransactionId: {row["TransactionId"]}, QuoteDate: {row["QuoteDate"]}");
                                }


                                // -------------------------
                                // Execute Rate reply detail SP
                                // -------------------------
                                cmd.CommandText = "dbo.Fedex_Quote_Rate_Reply_Detail_Importdata_20251108";
                                cmd.Parameters.Add(new SqlParameter
                                {
                                    ParameterName = "@DataToInsertRateReplyDetail",
                                    SqlDbType = SqlDbType.Structured,
                                    Value = dtRateReplyDetail,
                                    TypeName = "dbo.fedex_quote_rate_reply_detail_temp"
                                });
                                cmd.ExecuteNonQuery();
                                cmd.Parameters.Clear();

                                // -------------------------
                                // Execute Customer message SP
                                // -------------------------

                                try
                                {
                                    SqlContext.Pipe.Send("Starting Fedex_Quote_Customer_Message_Importdata_20251108...");




                                    cmd.CommandText = "dbo.Fedex_Quote_Customer_Message_Importdata_20251108";
                                    cmd.Parameters.Add(new SqlParameter
                                    {
                                        ParameterName = "@DataToInsertCustomerMessage",
                                        SqlDbType = SqlDbType.Structured,
                                        Value = dtCustomerMessage,
                                        TypeName = "dbo.fedex_quote_customer_message_temp"
                                    });



                                    SqlContext.Pipe.Send("Executing stored procedure…");

                                    cmd.ExecuteNonQuery();

                                    SqlContext.Pipe.Send("Stored procedure executed successfully.");
                                }
                                catch (SqlException ex)
                                {
                                    SqlContext.Pipe.Send("SQL ERROR occurred:");
                                    SqlContext.Pipe.Send("Message ERR: " + ex.Message);
                                    SqlContext.Pipe.Send("Line: " + ex.LineNumber);
                                    SqlContext.Pipe.Send("Procedure: " + ex.Procedure);
                                    SqlContext.Pipe.Send("Error Number: " + ex.Number);

                                    // optionally rethrow
                                    // throw;
                                }
                                catch (Exception ex)
                                {
                                    SqlContext.Pipe.Send("GENERAL ERROR occurred:");
                                    SqlContext.Pipe.Send("Message ERR: " + ex.Message);

                                    // optionally rethrow
                                    // throw;
                                }
                                finally
                                {
                                    cmd.Parameters.Clear();
                                    SqlContext.Pipe.Send("Parameters cleared.");
                                }

                                SqlContext.Pipe.Send($"Rows in DataTable: {dtCustomerMessage.Rows.Count}");
                                foreach (DataRow row in dtCustomerMessage.Rows)
                                {
                                    SqlContext.Pipe.Send($"Row TransactionId: {row["TransactionId"]}, Message: {row["Message"]}");
                                    SqlContext.Pipe.Send($"Row code: {row["code"]}");
                                }


                                // -------------------------
                                // Execute Rated Shipment Detail SP
                                // -------------------------
                                cmd.CommandText = "dbo.Fedex_Quote_Rated_Shipment_Detail_Importdata_20251108";
                                cmd.Parameters.Add(new SqlParameter
                                {
                                    ParameterName = "@DataToInserRatedShipmentDetail",
                                    SqlDbType = SqlDbType.Structured,
                                    Value = dtRatedShipmentDetail,
                                    TypeName = "dbo.fedex_quote_rated_shipment_detail_temp"
                                });
                                cmd.ExecuteNonQuery();
                                cmd.Parameters.Clear();

                                // -------------------------
                                // Execute Rated Surcharge SP
                                // -------------------------
                                cmd.CommandText = "dbo.Fedex_Quote_Surcharge_Importdata_20251108";
                                cmd.Parameters.Add(new SqlParameter
                                {
                                    ParameterName = "@DataToInsertSurcharge",
                                    SqlDbType = SqlDbType.Structured,
                                    Value = dtSurcharge,
                                    TypeName = "dbo.fedex_quote_surcharge_temp"
                                });
                                cmd.ExecuteNonQuery();
                                cmd.Parameters.Clear();

                                // -------------------------
                                // Execute Rated  package SP
                                // -------------------------
                                cmd.CommandText = "dbo.Fedex_Quote_RatedPackage_ImportData_20251108";
                                cmd.Parameters.Add(new SqlParameter
                                {
                                    ParameterName = "@DataToInsertRatedPackage",
                                    SqlDbType = SqlDbType.Structured,
                                    Value = dtRatedPackage,
                                    TypeName = "dbo.fedex_quote_ratedpackage_temp"
                                });
                                cmd.ExecuteNonQuery();
                                cmd.Parameters.Clear();

                                // -------------------------
                                // Execute Rated Service Name  SP
                                // -------------------------
                                cmd.CommandText = "dbo.Fedex_Quote_ServiceName_ImportData_20251108";
                                cmd.Parameters.Add(new SqlParameter
                                {
                                    ParameterName = "@DataToInsertServiceName",
                                    SqlDbType = SqlDbType.Structured,
                                    Value = dtServiceName,
                                    TypeName = "dbo.fedex_quote_service_name_temp"
                                });
                                cmd.ExecuteNonQuery();
                                cmd.Parameters.Clear();

                                // -------------------------
                                // Execute alerts SP
                                // -------------------------
                                cmd.CommandText = "dbo.Fedex_Quote_Alert_ImportData_Main_20251108";
                                cmd.Parameters.Add(new SqlParameter
                                {
                                    ParameterName = "@DataToInsertAlert",
                                    SqlDbType = SqlDbType.Structured,
                                    Value = dtServiceName,
                                    TypeName = "dbo.fedex_quote_alert_temp"
                                });
                                cmd.ExecuteNonQuery();
                                cmd.Parameters.Clear();



                            }
                        }

                        // Complete the transaction
                        scope.Complete();
                    }

                }
                catch (Exception ex)
                {
                    SendLongMessage("Database Error: " + ex.Message);
                }


            }
            catch (Exception ex)
            {
                HandleGeneralException(ex);
            }

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
            // string APIUrl = "https://apis.fedex.com/oauth/token";
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

        //Check if the tag is a list 
        public class SingleOrArrayConverter<T> : JsonConverter
        {
            public override bool CanConvert(Type objectType)
                => objectType == typeof(List<T>);

            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                var token = JToken.Load(reader);
                if (token.Type == JTokenType.Array)
                    return token.ToObject<List<T>>(serializer);

                return new List<T> { token.ToObject<T>(serializer) };
            }

            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
                => serializer.Serialize(writer, value);
        }

    }
}
