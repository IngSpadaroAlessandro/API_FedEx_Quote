using API_FedEx_Quote;
using System;
using System.Data;

public static class FedExTableFactory
{
    // ----------------------------------------------------------
    // Helpers
    // ----------------------------------------------------------
    private static DataTable CreateBaseTable(string tableName)
    {
        var dt = new DataTable(tableName);

        // Auto-increment primary key
        DataColumn idKeyColumn = new DataColumn("IdKey", typeof(int))
        {
            AutoIncrement = true,
            AutoIncrementSeed = 1,
            AutoIncrementStep = 1
        };

        dt.Columns.Add(idKeyColumn);

        return dt;
    }

    // ----------------------------------------------------------
    // FedExRateResponse
    // ----------------------------------------------------------
    public static DataTable CreateDT_FedExRateResponse()
    {
        var dt = CreateBaseTable("FedExRateResponse");

        dt.Columns.Add("TransactionId", typeof(string));
        dt.Columns.Add("CustomerTransactionId", typeof(string));
        dt.Columns.Add("QuoteDate", typeof(DateTime));
        dt.Columns.Add("Encoded", typeof(bool));

        return dt;
    }

    public static void AddRow_FedExRateResponse(DataTable dt, FedExRateResponse obj)
    {
        if (obj == null) return;

        var row = dt.NewRow();

        row["TransactionId"] = obj.TransactionId ?? string.Empty;
        row["CustomerTransactionId"] = obj.CustomerTransactionId ?? string.Empty;
        row["QuoteDate"] =obj.Output?.QuoteDate == null ? DBNull.Value: (object)obj.Output.QuoteDate.ToString();
        row["Encoded"] = obj.Output.Encoded;

        dt.Rows.Add(row);
    }



    // ----------------------------------------------------------
    // RateReplyDetail
    // ----------------------------------------------------------
    public static DataTable CreateDT_RateReplyDetail()
    {
        var dt = CreateBaseTable("RateReplyDetail");


        dt.Columns.Add("CustomerTransactionId", typeof(string));
        dt.Columns.Add("ServiceType", typeof(string));
        dt.Columns.Add("ServiceName", typeof(string));
        dt.Columns.Add("PackagingType", typeof(string));
        dt.Columns.Add("AnonymouslyAllowable", typeof(bool));

        dt.Columns.Add("OriginLocationIds", typeof(string));
        dt.Columns.Add("CommitDays", typeof(string));
        dt.Columns.Add("ServiceCode", typeof(string));
        dt.Columns.Add("AirportId", typeof(string));
        dt.Columns.Add("Scac", typeof(string));
        dt.Columns.Add("OriginServiceAreas", typeof(string));
        dt.Columns.Add("DeliveryDay", typeof(string));
        dt.Columns.Add("OriginLocationNumbers", typeof(int));
        dt.Columns.Add("DestinationPostalCode", typeof(string));
        dt.Columns.Add("CommitDate", typeof(DateTimeOffset));
        dt.Columns.Add("AstraDescription", typeof(string));
        dt.Columns.Add("DeliveryDate", typeof(string));
        dt.Columns.Add("DeliveryEligibilities", typeof(string));
        dt.Columns.Add("IneligibleForMoneyBackGuarantee", typeof(bool));
        dt.Columns.Add("MaximumTransitTime", typeof(string));
        dt.Columns.Add("AstraPlannedServiceLevel", typeof(string));
        dt.Columns.Add("DestinationLocationIds", typeof(string));
        dt.Columns.Add("DestinationLocationStateOrProvinceCodes", typeof(string));
        dt.Columns.Add("TransitTime", typeof(string));
        dt.Columns.Add("PackagingCode", typeof(string));
        dt.Columns.Add("DestinationLocationNumbers", typeof(int));
        dt.Columns.Add("PublishedDeliveryTime", typeof(string));
        dt.Columns.Add("CountryCodes", typeof(string));
        dt.Columns.Add("StateOrProvinceCodes", typeof(string));
        dt.Columns.Add("UrsaPrefixCode", typeof(string));
        dt.Columns.Add("UrsaSuffixCode", typeof(string));
        dt.Columns.Add("DestinationServiceAreas", typeof(string));
        dt.Columns.Add("OriginPostalCodes", typeof(string));
        dt.Columns.Add("CustomTransitTime", typeof(string));
        dt.Columns.Add("SignatureOptionType", typeof(string));
        dt.Columns.Add("CustomerTransactionId", typeof(string));
        dt.Columns.Add("ServiceId", typeof(string));
        dt.Columns.Add("ServiceType", typeof(string));
        dt.Columns.Add("Code", typeof(string));
        dt.Columns.Add("OperatingOrgCodes", typeof(string));
        dt.Columns.Add("ServiceCategory", typeof(string));
        dt.Columns.Add("Description", typeof(string));
        dt.Columns.Add("AstraDescription", typeof(string));
        dt.Columns.Add("CommitDayOfWeek", typeof(string));
        dt.Columns.Add("CommitDayCxsFormat", typeof(DateTime));


        return dt;
    }

    // ----------------------------------------------------------
    // CustomerMessage
    // ----------------------------------------------------------
    public static DataTable CreateDT_CustomerMessage()
    {
        var dt = CreateBaseTable("CustomerMessage");

        dt.Columns.Add("CustomerTransactionId", typeof(string));
        dt.Columns.Add("Code", typeof(string));
        dt.Columns.Add("Message", typeof(string));

        return dt;
    }

    // ----------------------------------------------------------
    // RatedShipmentDetail
    // ----------------------------------------------------------
    public static DataTable CreateDT_RatedShipmentDetail()
    {
        var dt = CreateBaseTable("RatedShipmentDetail");

        dt.Columns.Add("CustomerTransactionId", typeof(string));
        dt.Columns.Add("RateType", typeof(string));
        dt.Columns.Add("RatedWeightMethod", typeof(string));
        dt.Columns.Add("TotalDiscounts", typeof(decimal));
        dt.Columns.Add("TotalBaseCharge", typeof(decimal));
        dt.Columns.Add("TotalNetCharge", typeof(decimal));
        dt.Columns.Add("TotalVatCharge", typeof(decimal));
        dt.Columns.Add("TotalNetFedExCharge", typeof(decimal));
        dt.Columns.Add("TotalDutiesAndTaxes", typeof(decimal));
        dt.Columns.Add("NetTransportationAndPickupChargeAmount", typeof(decimal));
        dt.Columns.Add("NetTransportationAndPickupChargeCurrency", typeof(string));
        dt.Columns.Add("NetFedExTransportationAndPickupChargeAmount", typeof(decimal));
        dt.Columns.Add("NetFedExTransportationAndPickupChargeCurrency", typeof(string));
        dt.Columns.Add("PickupRateDetailRateType", typeof(string));
        dt.Columns.Add("PickupRateDetailRatingBasis", typeof(string));
        dt.Columns.Add("PickupRateDetailPricingCode", typeof(string));
        dt.Columns.Add("PickupRateDetailFuelSurchargePercent", typeof(decimal));

        dt.Columns.Add("TotalNetChargeWithDutiesAndTaxes", typeof(decimal));
        dt.Columns.Add("TotalDutiesTaxesAndFees", typeof(decimal));
        dt.Columns.Add("TotalAncillaryFeesAndTaxes", typeof(decimal));
        dt.Columns.Add("RateZone", typeof(string));
        dt.Columns.Add("DimDivisor", typeof(decimal));
        dt.Columns.Add("FuelSurchargePercent", typeof(decimal));
        dt.Columns.Add("TotalSurcharges", typeof(decimal));
        dt.Columns.Add("TotalFreightDiscount", typeof(decimal));
        dt.Columns.Add("PricingCode", typeof(string));
        dt.Columns.Add("FromCurrency", typeof(string));
        dt.Columns.Add("IntoCurrency", typeof(string));
        dt.Columns.Add("Rate", typeof(decimal));
        dt.Columns.Add("TotalBillingWeightUnits", typeof(string));
        dt.Columns.Add("TotalBillingWeightValue", typeof(decimal));
        dt.Columns.Add("ShipmentRateDetailCurrency", typeof(string));
        dt.Columns.Add("Currency", typeof(string));

        return dt;
    }

    
    // ----------------------------------------------------------
    // Surcharge
    // ----------------------------------------------------------
    public static DataTable CreateDT_Surcharge()
    {
        var dt = CreateBaseTable("Surcharge");

        dt.Columns.Add("CustomerTransactionId", typeof(string));
        dt.Columns.Add("Type", typeof(string));
        dt.Columns.Add("Description", typeof(string));
        dt.Columns.Add("Level", typeof(string));
        dt.Columns.Add("Amount", typeof(decimal));

        return dt;
    }


    // ----------------------------------------------------------
    // RatedPackage
    // ----------------------------------------------------------
    public static DataTable CreateDT_RatedPackage()
    {
        var dt = CreateBaseTable("RatedPackage");

        dt.Columns.Add("CustomerTransactionId", typeof(string));
        dt.Columns.Add("GroupNumber", typeof(int));
        dt.Columns.Add("EffectiveNetDiscount", typeof(decimal));

        dt.Columns.Add("RateType", typeof(string));
        dt.Columns.Add("RatedWeightMethod", typeof(string));
        dt.Columns.Add("BaseCharge", typeof(decimal));
        dt.Columns.Add("NetFreight", typeof(decimal));
        dt.Columns.Add("TotalSurcharges", typeof(decimal));
        dt.Columns.Add("NetFedExCharge", typeof(decimal));
        dt.Columns.Add("TotalTaxes", typeof(decimal));
        dt.Columns.Add("NetCharge", typeof(decimal));
        dt.Columns.Add("TotalRebates", typeof(decimal));

        // BillingWeight object
        dt.Columns.Add("BillingWeightUnits", typeof(string));
        dt.Columns.Add("BillingWeightValue", typeof(decimal));

        dt.Columns.Add("TotalFreightDiscounts", typeof(decimal));
        dt.Columns.Add("Currency", typeof(string));

        return dt;
    }

    // ----------------------------------------------------------
    // ServiceName
    // ----------------------------------------------------------
    public static DataTable CreateDT_ServiceName()
    {
        var dt = CreateBaseTable("ServiceName");

        dt.Columns.Add("CustomerTransactionId", typeof(string));
        dt.Columns.Add("Type", typeof(string));
        dt.Columns.Add("Encoding", typeof(string));
        dt.Columns.Add("Value", typeof(string));

        return dt;
    }


    private static object ToDbString(object value)
    {
        if (value == null)
            return DBNull.Value;

        string s = value.ToString();
        return string.IsNullOrWhiteSpace(s) ? DBNull.Value : (object)s;
    }


}
