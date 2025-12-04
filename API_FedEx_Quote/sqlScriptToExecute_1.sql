USE [API_Ship_v2]
GO
declare @jsonBody nvarchar(max) = '{
  "accountNumber": {
    "value": "XXXXX7354"
  },
  "requestedShipment": {
    "shipper": {
      "address": {
        "postalCode": "65247",
        "countryCode": "US"
      }
    },
    "recipient": {
      "address": {
        "postalCode": "72348",
        "countryCode": "US"
      }
    },
    "pickupType": "DROPOFF_AT_FEDEX_LOCATION",
    "rateRequestType": [
      "ACCOUNT",
      "LIST"
    ],
    "requestedPackageLineItems": [
      {
        "weight": {
          "units": "LB",
          "value": "10"
        }
      }
    ]
  }
}'
declare @postAuthData nvarchar(max) = 'grant_type=client_credentials&client_id=l7f1237972b45d4905a3908da4bdafea23&client_secret=cd1ff35d9a344e038d22d6137786e7b6'


DECLARE	@return_value int

EXEC	@return_value = [dbo].[FedEx_Quote_Rates_20251108]
		@jsonBody = @jsonBody,
		@postAuthData = @postAuthData

SELECT	'Return Value' = @return_value


-----------------------------------------------------------------------------------------------------------------------------------




DECLARE @strutturaTabellaRateResponse dbo.fedex_quote_rateresponse_temp;
SELECT *
INTO ##TempTableDataFedExRateResponseMain
FROM @strutturaTabellaRateResponse;
SELECT * 
FROM ##TempTableDataFedExRateResponseMain;


DECLARE @strutturaTabellaRateReplyDetail dbo.fedex_quote_rate_reply_detail_temp;
SELECT *
INTO ##TempTableDataFedexRateReplyDetail
FROM @strutturaTabellaRateReplyDetail;
SELECT *
FROM ##TempTableDataFedexRateReplyDetail;


DECLARE @strutturaTabellaCustomerMessage dbo.fedex_quote_customer_message_temp;
SELECT *
INTO ##TempTableDataCustomerMessage
FROM @strutturaTabellaCustomerMessage;
SELECT *
FROM ##TempTableDataCustomerMessage;

DECLARE @strutturaTabella dbo.fedex_quote_rated_shipment_detail_temp;
SELECT *
INTO ##TempTableDataRatedShipmentDetail
FROM @strutturaTabella;
SELECT *
FROM ##TempTableDataRatedShipmentDetail;


DECLARE @strutturaTabellaRatedPackage [dbo].[fedex_quote_ratedpackage_temp];
SELECT *
INTO ##TempTableDataFedexRatedPackage
FROM @strutturaTabellaRatedPackage;
SELECT *
FROM ##TempTableDataFedexRatedPackage;

DECLARE @strutturaTabellaServiceName [dbo].[fedex_quote_service_name_temp];
SELECT *
INTO ##TempTableDataFedexQuoteServiceName
FROM @strutturaTabellaServiceName;
SELECT *
FROM ##TempTableDataFedexQuoteServiceName;


DECLARE @strutturaTabellaSurcharge [dbo].[fedex_quote_surcharge_temp];
SELECT *
INTO ##TempTableFedexQuoteSurcharge
FROM @strutturaTabellaSurcharge;
SELECT *
FROM ##TempTableFedexQuoteSurcharge;


