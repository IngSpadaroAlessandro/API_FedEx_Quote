
/*------------------------------------------------------------------------------*/
/*------------------------------Creazione Tabelle Type--------------------------*/
/*-----------------------------------------------------------------------------*/

USE [Api_Ship_v2]
GO

/****** Object:  UserDefinedTableType [dbo].[fedex_quote_alert_temp]    Script Date: 12/5/2025 10:06:34 AM ******/
CREATE TYPE [dbo].[fedex_quote_alert_temp] AS TABLE(
	[IdKey] [int] NULL,
	[CustomerTransactionId] [nvarchar](100) NULL,
	[Code] [nvarchar](50) NULL,
	[Message] [nvarchar](max) NULL,
	[AlertType] [nvarchar](50) NULL
)
GO


-----------------------------------------------------------------------------------------

USE [Api_Ship_v2]
GO

/****** Object:  UserDefinedTableType [dbo].[fedex_quote_customer_message_temp]    Script Date: 12/5/2025 10:06:54 AM ******/
CREATE TYPE [dbo].[fedex_quote_customer_message_temp] AS TABLE(
	[IdKey] [int] NULL,
	[CustomerTransactionId] [nvarchar](100) NULL,
	[Code] [nvarchar](50) NULL,
	[Message] [nvarchar](max) NULL
)
GO



------------------------------------------------------------------------------------------------------

USE [Api_Ship_v2]
GO

/****** Object:  UserDefinedTableType [dbo].[fedex_quote_rate_reply_detail_temp]    Script Date: 12/5/2025 10:07:12 AM ******/
CREATE TYPE [dbo].[fedex_quote_rate_reply_detail_temp] AS TABLE(
	[IdKey] [int] NULL,
	[CustomerTransactionId] [nvarchar](100) NULL,
	[ServiceType] [nvarchar](50) NULL,
	[ServiceName] [nvarchar](100) NULL,
	[PackagingType] [nvarchar](50) NULL,
	[AnonymouslyAllowable] [bit] NULL,
	[OriginLocationIds] [nvarchar](50) NULL,
	[CommitDays] [nvarchar](50) NULL,
	[ServiceCode] [nvarchar](50) NULL,
	[AirportId] [nvarchar](50) NULL,
	[Scac] [nvarchar](50) NULL,
	[OriginServiceAreas] [nvarchar](50) NULL,
	[DeliveryDay] [nvarchar](50) NULL,
	[OriginLocationNumbers] [int] NULL,
	[DestinationPostalCode] [nvarchar](50) NULL,
	[CommitDate] [datetimeoffset](7) NULL,
	[AstraDescription] [nvarchar](50) NULL,
	[DeliveryDate] [datetimeoffset](7) NULL,
	[DeliveryEligibilities] [nvarchar](50) NULL,
	[IneligibleForMoneyBackGuarantee] [bit] NULL,
	[MaximumTransitTime] [nvarchar](50) NULL,
	[AstraPlannedServiceLevel] [nvarchar](50) NULL,
	[DestinationLocationIds] [nvarchar](50) NULL,
	[DestinationLocationStateOrProvinceCodes] [nvarchar](50) NULL,
	[TransitTime] [nvarchar](50) NULL,
	[PackagingCode] [nvarchar](50) NULL,
	[DestinationLocationNumbers] [int] NULL,
	[PublishedDeliveryTime] [time](7) NULL,
	[CountryCodes] [nvarchar](50) NULL,
	[StateOrProvinceCodes] [nvarchar](50) NULL,
	[UrsaPrefixCode] [nvarchar](50) NULL,
	[UrsaSuffixCode] [nvarchar](50) NULL,
	[DestinationServiceAreas] [nvarchar](50) NULL,
	[OriginPostalCodes] [nvarchar](50) NULL,
	[CustomTransitTime] [nvarchar](50) NULL,
	[SignatureOptionType] [nvarchar](50) NULL,
	[ServiceId] [nvarchar](50) NULL,
	[Code] [nvarchar](50) NULL,
	[OperatingOrgCodes] [nvarchar](200) NULL,
	[ServiceCategory] [nvarchar](50) NULL,
	[Description] [nvarchar](255) NULL,
	[CommitDayOfWeek] [nvarchar](50) NULL,
	[CommitDayCxsFormat] [datetimeoffset](7) NULL
)
GO


--------------------------------------------------------------------------------------

USE [Api_Ship_v2]
GO

/****** Object:  UserDefinedTableType [dbo].[fedex_quote_rated_shipment_detail_temp]    Script Date: 12/5/2025 10:07:35 AM ******/
CREATE TYPE [dbo].[fedex_quote_rated_shipment_detail_temp] AS TABLE(
	[IdKey] [int] NULL,
	[CustomerTransactionId] [nvarchar](100) NULL,
	[RateType] [nvarchar](50) NULL,
	[RatedWeightMethod] [nvarchar](50) NULL,
	[TotalDiscounts] [decimal](18, 4) NULL,
	[TotalBaseCharge] [decimal](18, 4) NULL,
	[TotalNetCharge] [decimal](18, 4) NULL,
	[TotalVatCharge] [decimal](18, 4) NULL,
	[TotalNetFedExCharge] [decimal](18, 4) NULL,
	[TotalDutiesAndTaxes] [decimal](18, 4) NULL,
	[NetTransportationAndPickupChargeAmount] [decimal](18, 4) NULL,
	[NetTransportationAndPickupChargeCurrency] [nvarchar](10) NULL,
	[NetFedExTransportationAndPickupChargeAmount] [decimal](18, 4) NULL,
	[NetFedExTransportationAndPickupChargeCurrency] [nvarchar](10) NULL,
	[PickupRateDetailRateType] [nvarchar](50) NULL,
	[PickupRateDetailRatingBasis] [nvarchar](50) NULL,
	[PickupRateDetailPricingCode] [nvarchar](50) NULL,
	[PickupRateDetailFuelSurchargePercent] [decimal](18, 4) NULL,
	[TotalNetChargeWithDutiesAndTaxes] [decimal](18, 4) NULL,
	[TotalDutiesTaxesAndFees] [decimal](18, 4) NULL,
	[TotalAncillaryFeesAndTaxes] [decimal](18, 4) NULL,
	[RateZone] [nvarchar](50) NULL,
	[DimDivisor] [decimal](18, 4) NULL,
	[FuelSurchargePercent] [decimal](18, 4) NULL,
	[TotalSurcharges] [decimal](18, 4) NULL,
	[TotalFreightDiscount] [decimal](18, 4) NULL,
	[PricingCode] [nvarchar](50) NULL,
	[FromCurrency] [nvarchar](10) NULL,
	[IntoCurrency] [nvarchar](10) NULL,
	[Rate] [decimal](18, 4) NULL,
	[TotalBillingWeightUnits] [nvarchar](10) NULL,
	[TotalBillingWeightValue] [decimal](18, 4) NULL,
	[ShipmentRateDetailCurrency] [nvarchar](10) NULL,
	[Currency] [nvarchar](10) NULL
)
GO


--------------------------------------------------------------------------------------

USE [Api_Ship_v2]
GO

/****** Object:  UserDefinedTableType [dbo].[fedex_quote_ratedpackage_temp]    Script Date: 12/5/2025 10:07:55 AM ******/
CREATE TYPE [dbo].[fedex_quote_ratedpackage_temp] AS TABLE(
	[IdKey] [int] NULL,
	[CustomerTransactionId] [nvarchar](100) NULL,
	[GroupNumber] [int] NULL,
	[EffectiveNetDiscount] [decimal](18, 4) NULL,
	[RateType] [nvarchar](100) NULL,
	[RatedWeightMethod] [nvarchar](100) NULL,
	[BaseCharge] [decimal](18, 4) NULL,
	[NetFreight] [decimal](18, 4) NULL,
	[TotalSurcharges] [decimal](18, 4) NULL,
	[NetFedExCharge] [decimal](18, 4) NULL,
	[TotalTaxes] [decimal](18, 4) NULL,
	[NetCharge] [decimal](18, 4) NULL,
	[TotalRebates] [decimal](18, 4) NULL,
	[BillingWeightUnits] [nvarchar](50) NULL,
	[BillingWeightValue] [decimal](18, 4) NULL,
	[TotalFreightDiscounts] [decimal](18, 4) NULL,
	[Currency] [nvarchar](20) NULL
)
GO


-------------------------------------------------------------------------------------

USE [Api_Ship_v2]
GO

/****** Object:  UserDefinedTableType [dbo].[fedex_quote_rateresponse_temp]    Script Date: 12/5/2025 10:08:06 AM ******/
CREATE TYPE [dbo].[fedex_quote_rateresponse_temp] AS TABLE(
	[IdKey] [int] NULL,
	[TransactionId] [nvarchar](100) NULL,
	[CustomerTransactionId] [nvarchar](100) NULL,
	[QuoteDate] [datetime] NULL,
	[Encoded] [bit] NULL
)
GO


--------------------------------------------------------------------------------------

USE [Api_Ship_v2]
GO

/****** Object:  UserDefinedTableType [dbo].[fedex_quote_service_name_temp]    Script Date: 12/5/2025 10:08:21 AM ******/
CREATE TYPE [dbo].[fedex_quote_service_name_temp] AS TABLE(
	[IdKey] [int] NULL,
	[CustomerTransactionId] [nvarchar](255) NULL,
	[Type] [nvarchar](255) NULL,
	[Encoding] [nvarchar](255) NULL,
	[Value] [nvarchar](max) NULL
)
GO


----------------------------------------------------------------------------------------------

USE [Api_Ship_v2]
GO

/****** Object:  UserDefinedTableType [dbo].[fedex_quote_surcharge_temp]    Script Date: 12/5/2025 10:08:38 AM ******/
CREATE TYPE [dbo].[fedex_quote_surcharge_temp] AS TABLE(
	[IdKey] [int] NULL,
	[CustomerTransactionId] [nvarchar](100) NULL,
	[Type] [nvarchar](100) NULL,
	[Description] [nvarchar](255) NULL,
	[Level] [nvarchar](100) NULL,
	[Amount] [decimal](18, 4) NULL
)
GO


/*------------------------------------------------------------------------------*/
/*------------------------------Creazione Stored procedure----------------------*/
/*-----------------------------------------------------------------------------*/


USE [Api_Ship_v2]
GO

/****** Object:  StoredProcedure [dbo].[Fedex_Quote_Alert_ImportData_Main_20251108]    Script Date: 12/5/2025 10:11:19 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[Fedex_Quote_Alert_ImportData_Main_20251108]
    @DataToInsertAlert dbo.fedex_quote_alert_temp READONLY
AS
BEGIN
    PRINT 'Inizio popolamento ##TempTableDataAlertFedexQuote';

    IF EXISTS (SELECT 1 FROM tempdb.sys.objects WHERE name = '##TempTableDataAlertFedexQuote')
    BEGIN
        DECLARE @StartIdKey INT = ISNULL((SELECT MAX(IdKey) FROM ##TempTableDataAlertFedexQuote), 0);

        INSERT INTO ##TempTableDataAlertFedexQuote
        (
            IdKey,
            CustomerTransactionId,
            Code,
            Message,
            AlertType
        )
        SELECT 
            ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) + @StartIdKey AS IdKey,
            CustomerTransactionId,
            Code,
            Message,
            AlertType
        FROM @DataToInsertAlert;

        PRINT '##TempTableDataAlertFedexQuote popolata con successo (append).';
    END
    ELSE
    BEGIN
        PRINT 'Temporary table ##TempTableDataAlertFedexQuote does not exist. Creating the table...';

        CREATE TABLE ##TempTableDataAlertFedexQuote
        (
            IdKey INT NULL,
            CustomerTransactionId NVARCHAR(100) NULL,
            Code NVARCHAR(50) NULL,
            Message NVARCHAR(MAX) NULL,
            AlertType NVARCHAR(50) NULL
        );

        INSERT INTO ##TempTableDataAlertFedexQuote
        (
            IdKey,
            CustomerTransactionId,
            Code,
            Message,
            AlertType
        )
        SELECT 
            ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) AS IdKey,
            CustomerTransactionId,
            Code,
            Message,
            AlertType
        FROM @DataToInsertAlert;

        PRINT '##TempTableDataAlertFedexQuote creata e popolata con successo.';
    END;
END;
GO


------------------------------------------------------------------------------------

USE [Api_Ship_v2]
GO

/****** Object:  StoredProcedure [dbo].[Fedex_Quote_Customer_Message_Importdata_20251108]    Script Date: 12/5/2025 10:11:32 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[Fedex_Quote_Customer_Message_Importdata_20251108]
    @DataToInsertCustomerMessage dbo.fedex_quote_customer_message_temp READONLY
AS
BEGIN
    PRINT 'Inizio popolamento ##TempTableDataCustomerMessage';

    IF EXISTS (SELECT 1 FROM tempdb.sys.objects WHERE name = '##TempTableDataCustomerMessage')
    BEGIN
        DECLARE @StartIdKey INT = ISNULL((SELECT MAX(IdKey) FROM ##TempTableDataCustomerMessage), 0);

        INSERT INTO ##TempTableDataCustomerMessage
        (
            IdKey,
            CustomerTransactionId,
            Code,
            [Message]
        )
        SELECT 
            ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) + @StartIdKey AS IdKey,
            CustomerTransactionId,
            Code,
            [Message]
        FROM @DataToInsertCustomerMessage;

        PRINT '##TempTableDataCustomerMessage popolata con successo (append).';
    END
    ELSE
    BEGIN
        PRINT 'Temporary table ##TempTableDataCustomerMessage does not exist. Creating the table...';

        CREATE TABLE ##TempTableDataCustomerMessage
        (
            IdKey INT NULL,
            CustomerTransactionId NVARCHAR(100) NULL,
            Code NVARCHAR(50) NULL,
            [Message] NVARCHAR(MAX) NULL
        );

        INSERT INTO ##TempTableDataCustomerMessage
        (
            IdKey,
            CustomerTransactionId,
            Code,
            [Message]
        )
        SELECT 
            ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) AS IdKey,
            CustomerTransactionId,
            Code,
            [Message]
        FROM @DataToInsertCustomerMessage;

        PRINT '##TempTableDataCustomerMessage creata e popolata con successo.';
    END;
END;
GO


--------------------------------------------------------------------------------------

USE [Api_Ship_v2]
GO

/****** Object:  StoredProcedure [dbo].[Fedex_Quote_Rate_Reply_Detail_Importdata_20251108]    Script Date: 12/5/2025 10:11:50 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[Fedex_Quote_Rate_Reply_Detail_Importdata_20251108]
    @DataToInsertRateReplyDetail dbo.fedex_quote_rate_reply_detail_temp READONLY
AS
BEGIN
    PRINT 'Inizio popolamento ##TempTableDataFedexRateReplyDetail';

    IF EXISTS (SELECT 1 FROM tempdb.sys.objects WHERE name = '##TempTableDataFedexRateReplyDetail')
    BEGIN
        DECLARE @StartIdKey INT = ISNULL((SELECT MAX(IdKey) FROM ##TempTableDataFedexRateReplyDetail), 0);

        INSERT INTO ##TempTableDataFedexRateReplyDetail
        (
            IdKey,
            CustomerTransactionId,
            ServiceType,
            ServiceName,
            PackagingType,
            AnonymouslyAllowable,
            OriginLocationIds,
            CommitDays,
            ServiceCode,
            AirportId,
            Scac,
            OriginServiceAreas,
            DeliveryDay,
            OriginLocationNumbers,
            DestinationPostalCode,
            CommitDate,
            AstraDescription,
            DeliveryDate,
            DeliveryEligibilities,
            IneligibleForMoneyBackGuarantee,
            MaximumTransitTime,
            AstraPlannedServiceLevel,
            DestinationLocationIds,
            DestinationLocationStateOrProvinceCodes,
            TransitTime,
            PackagingCode,
            DestinationLocationNumbers,
            PublishedDeliveryTime,
            CountryCodes,
            StateOrProvinceCodes,
            UrsaPrefixCode,
            UrsaSuffixCode,
            DestinationServiceAreas,
            OriginPostalCodes,
            CustomTransitTime,
            SignatureOptionType,
            ServiceId,
            Code,
            OperatingOrgCodes,
            ServiceCategory,
            Description,
            CommitDayOfWeek,
            CommitDayCxsFormat
        )
        SELECT 
            ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) + @StartIdKey AS IdKey,
            CustomerTransactionId,
            ServiceType,
            ServiceName,
            PackagingType,
            AnonymouslyAllowable,
            OriginLocationIds,
            CommitDays,
            ServiceCode,
            AirportId,
            Scac,
            OriginServiceAreas,
            DeliveryDay,
            OriginLocationNumbers,
            DestinationPostalCode,
            CommitDate,
            AstraDescription,
            DeliveryDate,
            DeliveryEligibilities,
            IneligibleForMoneyBackGuarantee,
            MaximumTransitTime,
            AstraPlannedServiceLevel,
            DestinationLocationIds,
            DestinationLocationStateOrProvinceCodes,
            TransitTime,
            PackagingCode,
            DestinationLocationNumbers,
            PublishedDeliveryTime,
            CountryCodes,
            StateOrProvinceCodes,
            UrsaPrefixCode,
            UrsaSuffixCode,
            DestinationServiceAreas,
            OriginPostalCodes,
            CustomTransitTime,
            SignatureOptionType,
            ServiceId,
            Code,
            OperatingOrgCodes,
            ServiceCategory,
            Description,
            CommitDayOfWeek,
            CommitDayCxsFormat
        FROM @DataToInsertRateReplyDetail;

        PRINT '##TempTableDataFedexRateReplyDetail popolata con successo (append).';
    END
    ELSE
    BEGIN
        PRINT 'Temporary table ##TempTableDataFedexRateReplyDetail does not exist. Creating the table...';

        CREATE TABLE ##TempTableDataFedexRateReplyDetail
        (
            IdKey INT NULL,
            CustomerTransactionId NVARCHAR(100) NULL,
            ServiceType NVARCHAR(50) NULL,
            ServiceName NVARCHAR(100) NULL,
            PackagingType NVARCHAR(50) NULL,
            AnonymouslyAllowable BIT NULL,
            OriginLocationIds NVARCHAR(50) NULL,
            CommitDays NVARCHAR(50) NULL,
            ServiceCode NVARCHAR(50) NULL,
            AirportId NVARCHAR(50) NULL,
            Scac NVARCHAR(50) NULL,
            OriginServiceAreas NVARCHAR(50) NULL,
            DeliveryDay NVARCHAR(50) NULL,
            OriginLocationNumbers INT NULL,
            DestinationPostalCode NVARCHAR(50) NULL,
            CommitDate DATETIMEOFFSET NULL,
            AstraDescription NVARCHAR(50) NULL,
            DeliveryDate DATETIMEOFFSET NULL,
            DeliveryEligibilities NVARCHAR(50) NULL,
            IneligibleForMoneyBackGuarantee BIT NULL,
            MaximumTransitTime NVARCHAR(50) NULL,
            AstraPlannedServiceLevel NVARCHAR(50) NULL,
            DestinationLocationIds NVARCHAR(50) NULL,
            DestinationLocationStateOrProvinceCodes NVARCHAR(50) NULL,
            TransitTime NVARCHAR(50) NULL,
            PackagingCode NVARCHAR(50) NULL,
            DestinationLocationNumbers INT NULL,
            PublishedDeliveryTime TIME NULL,
            CountryCodes NVARCHAR(50) NULL,
            StateOrProvinceCodes NVARCHAR(50) NULL,
            UrsaPrefixCode NVARCHAR(50) NULL,
            UrsaSuffixCode NVARCHAR(50) NULL,
            DestinationServiceAreas NVARCHAR(50) NULL,
            OriginPostalCodes NVARCHAR(50) NULL,
            CustomTransitTime NVARCHAR(50) NULL,
            SignatureOptionType NVARCHAR(50) NULL,
            ServiceId NVARCHAR(50) NULL,
            Code NVARCHAR(50) NULL,
            OperatingOrgCodes NVARCHAR(200) NULL,
            ServiceCategory NVARCHAR(50) NULL,
            Description NVARCHAR(255) NULL,
            CommitDayOfWeek NVARCHAR(50) NULL,
            CommitDayCxsFormat DATETIMEOFFSET NULL
        );

        INSERT INTO ##TempTableDataFedexRateReplyDetail
        (
            IdKey,
            CustomerTransactionId,
            ServiceType,
            ServiceName,
            PackagingType,
            AnonymouslyAllowable,
            OriginLocationIds,
            CommitDays,
            ServiceCode,
            AirportId,
            Scac,
            OriginServiceAreas,
            DeliveryDay,
            OriginLocationNumbers,
            DestinationPostalCode,
            CommitDate,
            AstraDescription,
            DeliveryDate,
            DeliveryEligibilities,
            IneligibleForMoneyBackGuarantee,
            MaximumTransitTime,
            AstraPlannedServiceLevel,
            DestinationLocationIds,
            DestinationLocationStateOrProvinceCodes,
            TransitTime,
            PackagingCode,
            DestinationLocationNumbers,
            PublishedDeliveryTime,
            CountryCodes,
            StateOrProvinceCodes,
            UrsaPrefixCode,
            UrsaSuffixCode,
            DestinationServiceAreas,
            OriginPostalCodes,
            CustomTransitTime,
            SignatureOptionType,
            ServiceId,
            Code,
            OperatingOrgCodes,
            ServiceCategory,
            Description,
            CommitDayOfWeek,
            CommitDayCxsFormat
        )
        SELECT 
            ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) AS IdKey,
            CustomerTransactionId,
            ServiceType,
            ServiceName,
            PackagingType,
            AnonymouslyAllowable,
            OriginLocationIds,
            CommitDays,
            ServiceCode,
            AirportId,
            Scac,
            OriginServiceAreas,
            DeliveryDay,
            OriginLocationNumbers,
            DestinationPostalCode,
            CommitDate,
            AstraDescription,
            DeliveryDate,
            DeliveryEligibilities,
            IneligibleForMoneyBackGuarantee,
            MaximumTransitTime,
            AstraPlannedServiceLevel,
            DestinationLocationIds,
            DestinationLocationStateOrProvinceCodes,
            TransitTime,
            PackagingCode,
            DestinationLocationNumbers,
            PublishedDeliveryTime,
            CountryCodes,
            StateOrProvinceCodes,
            UrsaPrefixCode,
            UrsaSuffixCode,
            DestinationServiceAreas,
            OriginPostalCodes,
            CustomTransitTime,
            SignatureOptionType,
            ServiceId,
            Code,
            OperatingOrgCodes,
            ServiceCategory,
            Description,
            CommitDayOfWeek,
            CommitDayCxsFormat
        FROM @DataToInsertRateReplyDetail;

        PRINT '##TempTableDataFedexRateReplyDetail creata e popolata con successo.';
    END;
END;
GO


----------------------------------------------------------------------------------

USE [Api_Ship_v2]
GO

/****** Object:  StoredProcedure [dbo].[Fedex_Quote_Rated_Shipment_Detail_Importdata_20251108]    Script Date: 12/5/2025 10:12:06 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Fedex_Quote_Rated_Shipment_Detail_Importdata_20251108]
    @DataToInserRatedShipmentDetail dbo.fedex_quote_rated_shipment_detail_temp READONLY
AS
BEGIN
    PRINT 'Starting population of ##TempTableDataRatedShipmentDetail';

    IF EXISTS (SELECT 1 FROM tempdb.sys.objects WHERE name = '##TempTableDataRatedShipmentDetail')
    BEGIN
        DECLARE @StartIdKey INT = ISNULL((SELECT MAX(IdKey) FROM ##TempTableDataRatedShipmentDetail), 0);

        INSERT INTO ##TempTableDataRatedShipmentDetail
        (
            IdKey,
            CustomerTransactionId,
            RateType,
            RatedWeightMethod,
            TotalDiscounts,
            TotalBaseCharge,
            TotalNetCharge,
            TotalVatCharge,
            TotalNetFedExCharge,
            TotalDutiesAndTaxes,
            NetTransportationAndPickupChargeAmount,
            NetTransportationAndPickupChargeCurrency,
            NetFedExTransportationAndPickupChargeAmount,
            NetFedExTransportationAndPickupChargeCurrency,
            PickupRateDetailRateType,
            PickupRateDetailRatingBasis,
            PickupRateDetailPricingCode,
            PickupRateDetailFuelSurchargePercent,
            TotalNetChargeWithDutiesAndTaxes,
            TotalDutiesTaxesAndFees,
            TotalAncillaryFeesAndTaxes,
            RateZone,
            DimDivisor,
            FuelSurchargePercent,
            TotalSurcharges,
            TotalFreightDiscount,
            PricingCode,
            FromCurrency,
            IntoCurrency,
            Rate,
            TotalBillingWeightUnits,
            TotalBillingWeightValue,
            ShipmentRateDetailCurrency,
            Currency
        )
        SELECT
            ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) + @StartIdKey,
            CustomerTransactionId,
            RateType,
            RatedWeightMethod,
            TotalDiscounts,
            TotalBaseCharge,
            TotalNetCharge,
            TotalVatCharge,
            TotalNetFedExCharge,
            TotalDutiesAndTaxes,
            NetTransportationAndPickupChargeAmount,
            NetTransportationAndPickupChargeCurrency,
            NetFedExTransportationAndPickupChargeAmount,
            NetFedExTransportationAndPickupChargeCurrency,
            PickupRateDetailRateType,
            PickupRateDetailRatingBasis,
            PickupRateDetailPricingCode,
            PickupRateDetailFuelSurchargePercent,
            TotalNetChargeWithDutiesAndTaxes,
            TotalDutiesTaxesAndFees,
            TotalAncillaryFeesAndTaxes,
            RateZone,
            DimDivisor,
            FuelSurchargePercent,
            TotalSurcharges,
            TotalFreightDiscount,
            PricingCode,
            FromCurrency,
            IntoCurrency,
            Rate,
            TotalBillingWeightUnits,
            TotalBillingWeightValue,
            ShipmentRateDetailCurrency,
            Currency
        FROM @DataToInserRatedShipmentDetail;

        PRINT '##TempTableDataRatedShipmentDetail successfully appended.';
    END
    ELSE
    BEGIN
        PRINT 'Temp table missing. Creating ##TempTableDataRatedShipmentDetail...';

        CREATE TABLE ##TempTableDataRatedShipmentDetail
        (
            IdKey INT NULL,
            CustomerTransactionId NVARCHAR(100) NULL,
            RateType NVARCHAR(50) NULL,
            RatedWeightMethod NVARCHAR(50) NULL,
            TotalDiscounts DECIMAL(18,4) NULL,
            TotalBaseCharge DECIMAL(18,4) NULL,
            TotalNetCharge DECIMAL(18,4) NULL,
            TotalVatCharge DECIMAL(18,4) NULL,
            TotalNetFedExCharge DECIMAL(18,4) NULL,
            TotalDutiesAndTaxes DECIMAL(18,4) NULL,
            NetTransportationAndPickupChargeAmount DECIMAL(18,4) NULL,
            NetTransportationAndPickupChargeCurrency NVARCHAR(10) NULL,
            NetFedExTransportationAndPickupChargeAmount DECIMAL(18,4) NULL,
            NetFedExTransportationAndPickupChargeCurrency NVARCHAR(10) NULL,
            PickupRateDetailRateType NVARCHAR(50) NULL,
            PickupRateDetailRatingBasis NVARCHAR(50) NULL,
            PickupRateDetailPricingCode NVARCHAR(50) NULL,
            PickupRateDetailFuelSurchargePercent DECIMAL(18,4) NULL,
            TotalNetChargeWithDutiesAndTaxes DECIMAL(18,4) NULL,
            TotalDutiesTaxesAndFees DECIMAL(18,4) NULL,
            TotalAncillaryFeesAndTaxes DECIMAL(18,4) NULL,
            RateZone NVARCHAR(50) NULL,
            DimDivisor DECIMAL(18,4) NULL,
            FuelSurchargePercent DECIMAL(18,4) NULL,
            TotalSurcharges DECIMAL(18,4) NULL,
            TotalFreightDiscount DECIMAL(18,4) NULL,
            PricingCode NVARCHAR(50) NULL,
            FromCurrency NVARCHAR(10) NULL,
            IntoCurrency NVARCHAR(10) NULL,
            Rate DECIMAL(18,4) NULL,
            TotalBillingWeightUnits NVARCHAR(10) NULL,
            TotalBillingWeightValue DECIMAL(18,4) NULL,
            ShipmentRateDetailCurrency NVARCHAR(10) NULL,
            Currency NVARCHAR(10) NULL
        );

        INSERT INTO ##TempTableDataRatedShipmentDetail
        SELECT 
            ROW_NUMBER() OVER (ORDER BY (SELECT NULL)),
            CustomerTransactionId,
            RateType,
            RatedWeightMethod,
            TotalDiscounts,
            TotalBaseCharge,
            TotalNetCharge,
            TotalVatCharge,
            TotalNetFedExCharge,
            TotalDutiesAndTaxes,
            NetTransportationAndPickupChargeAmount,
            NetTransportationAndPickupChargeCurrency,
            NetFedExTransportationAndPickupChargeAmount,
            NetFedExTransportationAndPickupChargeCurrency,
            PickupRateDetailRateType,
            PickupRateDetailRatingBasis,
            PickupRateDetailPricingCode,
            PickupRateDetailFuelSurchargePercent,
            TotalNetChargeWithDutiesAndTaxes,
            TotalDutiesTaxesAndFees,
            TotalAncillaryFeesAndTaxes,
            RateZone,
            DimDivisor,
            FuelSurchargePercent,
            TotalSurcharges,
            TotalFreightDiscount,
            PricingCode,
            FromCurrency,
            IntoCurrency,
            Rate,
            TotalBillingWeightUnits,
            TotalBillingWeightValue,
            ShipmentRateDetailCurrency,
            Currency
        FROM @DataToInserRatedShipmentDetail;

        PRINT '##TempTableDataRatedShipmentDetail created and populated.';
    END
END
GO


--------------------------------------------------------------------------------------

USE [Api_Ship_v2]
GO

/****** Object:  StoredProcedure [dbo].[Fedex_Quote_RatedPackage_ImportData_20251108]    Script Date: 12/5/2025 10:12:23 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Fedex_Quote_RatedPackage_ImportData_20251108]
    @DataToInsertRatedPackage dbo.fedex_quote_ratedpackage_temp READONLY
AS
BEGIN
    PRINT 'Populating ##TempTableDataFedexRatedPackage...';

    IF EXISTS (SELECT 1 FROM tempdb.sys.objects WHERE name = '##TempTableDataFedexRatedPackage')
    BEGIN
        DECLARE @StartIdKey INT = ISNULL((SELECT MAX(IdKey) FROM ##TempTableDataFedexRatedPackage), 0);

        INSERT INTO ##TempTableDataFedexRatedPackage
        (
            IdKey,
            CustomerTransactionId,
            GroupNumber,
            EffectiveNetDiscount,
            RateType,
            RatedWeightMethod,
            BaseCharge,
            NetFreight,
            TotalSurcharges,
            NetFedExCharge,
            TotalTaxes,
            NetCharge,
            TotalRebates,
            BillingWeightUnits,
            BillingWeightValue,
            TotalFreightDiscounts,
            Currency
        )
        SELECT
            ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) + @StartIdKey,
            CustomerTransactionId,
            GroupNumber,
            EffectiveNetDiscount,
            RateType,
            RatedWeightMethod,
            BaseCharge,
            NetFreight,
            TotalSurcharges,
            NetFedExCharge,
            TotalTaxes,
            NetCharge,
            TotalRebates,
            BillingWeightUnits,
            BillingWeightValue,
            TotalFreightDiscounts,
            Currency
        FROM @DataToInsertRatedPackage;

        PRINT '##TempTableDataFedexRatedPackage appended successfully.';
    END
    ELSE
    BEGIN
        PRINT 'Temporary table does not exist. Creating ##TempTableDataFedexRatedPackage...';

        CREATE TABLE ##TempTableDataFedexRatedPackage
        (
            IdKey INT NULL,
            CustomerTransactionId NVARCHAR(100) NULL,
            GroupNumber INT NULL,
            EffectiveNetDiscount DECIMAL(18,4) NULL,
            RateType NVARCHAR(100) NULL,
            RatedWeightMethod NVARCHAR(100) NULL,
            BaseCharge DECIMAL(18,4) NULL,
            NetFreight DECIMAL(18,4) NULL,
            TotalSurcharges DECIMAL(18,4) NULL,
            NetFedExCharge DECIMAL(18,4) NULL,
            TotalTaxes DECIMAL(18,4) NULL,
            NetCharge DECIMAL(18,4) NULL,
            TotalRebates DECIMAL(18,4) NULL,
            BillingWeightUnits NVARCHAR(50) NULL,
            BillingWeightValue DECIMAL(18,4) NULL,
            TotalFreightDiscounts DECIMAL(18,4) NULL,
            Currency NVARCHAR(20) NULL
        );

        INSERT INTO ##TempTableDataFedexRatedPackage
        (
            IdKey,
            CustomerTransactionId,
            GroupNumber,
            EffectiveNetDiscount,
            RateType,
            RatedWeightMethod,
            BaseCharge,
            NetFreight,
            TotalSurcharges,
            NetFedExCharge,
            TotalTaxes,
            NetCharge,
            TotalRebates,
            BillingWeightUnits,
            BillingWeightValue,
            TotalFreightDiscounts,
            Currency
        )
        SELECT
            ROW_NUMBER() OVER (ORDER BY (SELECT NULL)),
            CustomerTransactionId,
            GroupNumber,
            EffectiveNetDiscount,
            RateType,
            RatedWeightMethod,
            BaseCharge,
            NetFreight,
            TotalSurcharges,
            NetFedExCharge,
            TotalTaxes,
            NetCharge,
            TotalRebates,
            BillingWeightUnits,
            BillingWeightValue,
            TotalFreightDiscounts,
            Currency
        FROM @DataToInsertRatedPackage;

        PRINT '##TempTableDataFedexRatedPackage created and populated successfully.';
    END
END;
GO


-----------------------------------------------------------------------------------

USE [Api_Ship_v2]
GO

/****** Object:  StoredProcedure [dbo].[Fedex_Quote_RateResponse_ImportData_Main_20251108]    Script Date: 12/5/2025 10:12:51 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[Fedex_Quote_RateResponse_ImportData_Main_20251108]
    @DataToInsertMain dbo.fedex_quote_rateresponse_temp READONLY
AS
BEGIN
    PRINT 'Inizio popolamento ##TempTableDataFedExRateResponseMain';

    IF EXISTS (SELECT 1 FROM tempdb.sys.objects WHERE name = '##TempTableDataFedExRateResponseMain')
    BEGIN
        DECLARE @StartIdKey INT = ISNULL((SELECT MAX(IdKey) FROM ##TempTableDataFedExRateResponseMain), 0);

        INSERT INTO ##TempTableDataFedExRateResponseMain
        (
            IdKey,
            TransactionId,
            CustomerTransactionId,
            QuoteDate,
            Encoded
        )
        SELECT 
            ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) + @StartIdKey AS IdKey,
            TransactionId,
            CustomerTransactionId,
            QuoteDate,
            Encoded
        FROM @DataToInsertMain;

        PRINT '##TempTableDataFedExRateResponseMain popolata con successo (append).';
    END
    ELSE
    BEGIN
        PRINT 'Temporary table ##TempTableDataFedExRateResponseMain does not exist. Creating the table...';

        CREATE TABLE ##TempTableDataFedExRateResponseMain
        (
            IdKey INT NULL,
            TransactionId NVARCHAR(100) NULL,
            CustomerTransactionId NVARCHAR(100) NULL,
            QuoteDate DATETIME NULL,
            Encoded BIT NULL
        );

        INSERT INTO ##TempTableDataFedExRateResponseMain
        (
            IdKey,
            TransactionId,
            CustomerTransactionId,
            QuoteDate,
            Encoded
        )
        SELECT 
            ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) AS IdKey,
            TransactionId,
            CustomerTransactionId,
            QuoteDate,
            Encoded
        FROM @DataToInsertMain;

        PRINT '##TempTableDataFedExRateResponseMain creata e popolata con successo.';
    END;
END;
GO


---------------------------------------------------------------------------------------

USE [Api_Ship_v2]
GO

/****** Object:  StoredProcedure [dbo].[Fedex_Quote_ServiceName_ImportData_20251108]    Script Date: 12/5/2025 10:13:12 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- STORED PROCEDURE: Fedex_Quote_ServiceName_ImportData
-- =============================================
CREATE PROCEDURE [dbo].[Fedex_Quote_ServiceName_ImportData_20251108]
(
    @DataToInsertServiceName dbo.fedex_quote_service_name_temp READONLY
)
AS
BEGIN
    PRINT 'Populating ##TempTableDataFedexQuoteServiceName...';

    IF EXISTS (SELECT 1 FROM tempdb.sys.objects WHERE name = '##TempTableDataFedexQuoteServiceName')
    BEGIN
        DECLARE @StartIdKey INT = ISNULL((SELECT MAX(IdKey) FROM ##TempTableDataFedexQuoteServiceName), 0);

        INSERT INTO ##TempTableDataFedexQuoteServiceName
        (
            IdKey,
            CustomerTransactionId,
            Type,
            Encoding,
            Value
        )
        SELECT
            ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) + @StartIdKey AS IdKey,
            CustomerTransactionId,
            Type,
            Encoding,
            Value
        FROM @DataToInsertServiceName;

        PRINT '##TempTableDataFedexQuoteServiceName appended successfully.';
    END
    ELSE
    BEGIN
        PRINT 'Temporary table does not exist. Creating ##TempTableDataFedexQuoteServiceName...';

        CREATE TABLE ##TempTableDataFedexQuoteServiceName
        (
            IdKey INT NULL,
            CustomerTransactionId NVARCHAR(255) NULL,
            Type NVARCHAR(255) NULL,
            Encoding NVARCHAR(255) NULL,
            Value NVARCHAR(MAX) NULL
        );

        INSERT INTO ##TempTableDataFedexQuoteServiceName
        (
            IdKey,
            CustomerTransactionId,
            Type,
            Encoding,
            Value
        )
        SELECT
            ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) AS IdKey,
            CustomerTransactionId,
            Type,
            Encoding,
            Value
        FROM @DataToInsertServiceName;

        PRINT '##TempTableDataFedexQuoteServiceName created and populated successfully.';
    END;
END;
GO


---------------------------------------------------------------------------------------

USE [Api_Ship_v2]
GO

/****** Object:  StoredProcedure [dbo].[Fedex_Quote_Surcharge_Importdata_20251108]    Script Date: 12/5/2025 10:13:30 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[Fedex_Quote_Surcharge_Importdata_20251108]
    @DataToInsertSurcharge dbo.fedex_quote_surcharge_temp READONLY
AS
BEGIN
    PRINT 'Starting population of ##TempTableFedexQuoteSurcharge';

    IF EXISTS (SELECT 1 FROM tempdb.sys.objects WHERE name = '##TempTableFedexQuoteSurcharge')
    BEGIN
        DECLARE @StartIdKey INT = ISNULL((SELECT MAX(IdKey) FROM ##TempTableFedexQuoteSurcharge), 0);

        INSERT INTO ##TempTableFedexQuoteSurcharge
        (
            IdKey,
            CustomerTransactionId,
            Type,
            Description,
            Level,
            Amount
        )
        SELECT
            ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) + @StartIdKey AS IdKey,
            CustomerTransactionId,
            Type,
            Description,
            Level,
            Amount
        FROM @DataToInsertSurcharge;

        PRINT '##TempTableFedexQuoteSurcharge successfully appended.';
    END
    ELSE
    BEGIN
        PRINT 'Temporary table ##TempTableFedexQuoteSurcharge does not exist. Creating the table...';

        CREATE TABLE ##TempTableFedexQuoteSurcharge
        (
            IdKey INT NULL,
            CustomerTransactionId NVARCHAR(100) NULL,
            Type NVARCHAR(100) NULL,
            Description NVARCHAR(255) NULL,
            Level NVARCHAR(100) NULL,
            Amount DECIMAL(18,4) NULL
        );

        INSERT INTO ##TempTableFedexQuoteSurcharge
        (
            IdKey,
            CustomerTransactionId,
            Type,
            Description,
            Level,
            Amount
        )
        SELECT
            ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) AS IdKey,
            CustomerTransactionId,
            Type,
            Description,
            Level,
            Amount
        FROM @DataToInsertSurcharge;

        PRINT '##TempTableFedexQuoteSurcharge created and populated successfully.';
    END;
END;
GO



/*------------------------------------------------------------------------------*/
/*------------------------------TEST CHIAMATA----------------------------------*/
/*-----------------------------------------------------------------------------*/

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


--------------------------------------------------------------------------------------------------




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



DECLARE @strutturaTabellaAlert [dbo].[fedex_quote_alert_temp];
SELECT *
INTO ##TempTableDataAlertFedexQuote
FROM @strutturaTabellaAlert;
SELECT *
FROM ##TempTableDataAlertFedexQuote;

