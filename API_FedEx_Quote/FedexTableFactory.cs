using API_FedEx_Quote;
using Microsoft.SqlServer.Server;
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

    public static void CreateRow_FedExRateResponse(DataTable dt, FedExRateResponse obj)
    {
        var row = dt.NewRow();

        row["TransactionId"] = ToDbString(obj?.TransactionId);
        row["CustomerTransactionId"] = ToDbString(obj?.CustomerTransactionId);

        // QuoteDate stored as string even if you parse it elsewhere
        row["QuoteDate"] = ToDbString(obj?.Output?.QuoteDate);

        row["Encoded"] = ToDbString(obj?.Output.Encoded);
        SqlContext.Pipe.Send("row[QuoteDate]: " + row["QuoteDate"]);
        SqlContext.Pipe.Send("row[Encoded]: " + row["Encoded"]);

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
        dt.Columns.Add("DeliveryDate", typeof(DateTimeOffset));
        dt.Columns.Add("DeliveryEligibilities", typeof(string));
        dt.Columns.Add("IneligibleForMoneyBackGuarantee", typeof(bool));
        dt.Columns.Add("MaximumTransitTime", typeof(string));
        dt.Columns.Add("AstraPlannedServiceLevel", typeof(string));
        dt.Columns.Add("DestinationLocationIds", typeof(string));
        dt.Columns.Add("DestinationLocationStateOrProvinceCodes", typeof(string));
        dt.Columns.Add("TransitTime", typeof(string));
        dt.Columns.Add("PackagingCode", typeof(string));
        dt.Columns.Add("DestinationLocationNumbers", typeof(int));
        dt.Columns.Add("PublishedDeliveryTime", typeof(TimeSpan));
        dt.Columns.Add("CountryCodes", typeof(string));
        dt.Columns.Add("StateOrProvinceCodes", typeof(string));
        dt.Columns.Add("UrsaPrefixCode", typeof(string));
        dt.Columns.Add("UrsaSuffixCode", typeof(string));
        dt.Columns.Add("DestinationServiceAreas", typeof(string));
        dt.Columns.Add("OriginPostalCodes", typeof(string));
        dt.Columns.Add("CustomTransitTime", typeof(string));
        dt.Columns.Add("SignatureOptionType", typeof(string));
        dt.Columns.Add("ServiceId", typeof(string));
        dt.Columns.Add("Code", typeof(string));
        dt.Columns.Add("OperatingOrgCodes", typeof(string));
        dt.Columns.Add("ServiceCategory", typeof(string));
        dt.Columns.Add("Description", typeof(string));
        dt.Columns.Add("CommitDayOfWeek", typeof(string));
        dt.Columns.Add("CommitDayCxsFormat", typeof(DateTimeOffset));


        return dt;
    }

    public static void CreateRow_RateReplyDetail(DataTable dt, RateReplyDetail rateReplyDetail, string customerTransactionId)
    {
        var row = dt.NewRow();

        row["CustomerTransactionId"] = ToDbString(customerTransactionId);
        row["ServiceType"] = ToDbString(rateReplyDetail?.ServiceType);
        row["ServiceName"] = ToDbString(rateReplyDetail?.ServiceName);
        row["PackagingType"] = ToDbString(rateReplyDetail?.PackagingType);
        row["AnonymouslyAllowable"] = ToDbString(rateReplyDetail?.AnonymouslyAllowable);

        // OperationalDetail
        var od = rateReplyDetail?.OperationalDetail;

        row["OriginLocationIds"] = ToDbString(od?.OriginLocationIds);
        row["CommitDays"] = ToDbString(od?.CommitDays);
        row["ServiceCode"] = ToDbString(od?.ServiceCode);
        row["AirportId"] = ToDbString(od?.AirportId);
        row["Scac"] = ToDbString(od?.Scac);
        row["OriginServiceAreas"] = ToDbString(od?.OriginServiceAreas);
        row["DeliveryDay"] = ToDbString(od?.DeliveryDay);
        row["OriginLocationNumbers"] = ToDbString(od?.OriginLocationNumbers);
        row["DestinationPostalCode"] = ToDbString(od?.DestinationPostalCode);
        row["CommitDate"] = ToDbString(od?.CommitDate);
        row["AstraDescription"] = ToDbString(od?.AstraDescription);
        row["DeliveryDate"] = ToDbString(od?.DeliveryDate);
        row["DeliveryEligibilities"] = ToDbString(od?.DeliveryEligibilities);
        row["IneligibleForMoneyBackGuarantee"] = ToDbString(od?.IneligibleForMoneyBackGuarantee);
        row["MaximumTransitTime"] = ToDbString(od?.MaximumTransitTime);
        row["AstraPlannedServiceLevel"] = ToDbString(od?.AstraPlannedServiceLevel);
        row["DestinationLocationIds"] = ToDbString(od?.DestinationLocationIds);
        row["DestinationLocationStateOrProvinceCodes"] = ToDbString(od?.DestinationLocationStateOrProvinceCodes);
        row["TransitTime"] = ToDbString(od?.TransitTime);
        row["PackagingCode"] = ToDbString(od?.PackagingCode);
        row["DestinationLocationNumbers"] = ToDbString(od?.DestinationLocationNumbers);
        row["PublishedDeliveryTime"] = ToDbString(od?.PublishedDeliveryTime);
        row["CountryCodes"] = ToDbString(od?.CountryCodes);
        row["StateOrProvinceCodes"] = ToDbString(od?.StateOrProvinceCodes);
        row["UrsaPrefixCode"] = ToDbString(od?.UrsaPrefixCode);
        row["UrsaSuffixCode"] = ToDbString(od?.UrsaSuffixCode);
        row["DestinationServiceAreas"] = ToDbString(od?.DestinationServiceAreas);
        row["OriginPostalCodes"] = ToDbString(od?.OriginPostalCodes);
        row["CustomTransitTime"] = ToDbString(od?.CustomTransitTime);

        // ServiceDescription
        var sd = rateReplyDetail?.ServiceDescription;

        row["ServiceId"] = ToDbString(sd?.ServiceId);
        row["Code"] = ToDbString(sd?.Code);

        // Join array to CSV
        row["OperatingOrgCodes"] = sd?.OperatingOrgCodes != null && sd.OperatingOrgCodes.Count > 0
                                   ? string.Join(",", sd.OperatingOrgCodes)
                                   : (object)DBNull.Value;

        row["ServiceCategory"] = ToDbString(sd?.ServiceCategory);
        row["Description"] = ToDbString(sd?.Description);

        // Commit
        var commit = rateReplyDetail?.Commit?.DateDetail;

        row["CommitDayOfWeek"] = ToDbString(commit?.DayOfWeek);
        row["CommitDayCxsFormat"] = ToDbString(commit?.DayCxsFormat);

        dt.Rows.Add(row);
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

    public static void CreateRow_CustomerMessage(DataTable dt, CustomerMessage obj, string customerTransactionId)
    {
        var row = dt.NewRow();

        row["CustomerTransactionId"] = ToDbString(customerTransactionId);
        row["Code"] = ToDbString(obj?.Code);
        row["Message"] = ToDbString(obj?.Message);

        dt.Rows.Add(row);
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

    public static void CreateRow_RatedShipmentDetail(DataTable dt, RatedShipmentDetail obj, string customerTransactionId)
    {
        var row = dt.NewRow();

        row["CustomerTransactionId"] = ToDbString(customerTransactionId);
        row["RateType"] = ToDbString(obj?.RateType);
        row["RatedWeightMethod"] = ToDbString(obj?.RatedWeightMethod);
        row["TotalDiscounts"] = ToDbString(obj?.TotalDiscounts);
        row["TotalBaseCharge"] = ToDbString(obj?.TotalBaseCharge);
        row["TotalNetCharge"] = ToDbString(obj?.TotalNetCharge);
        row["TotalVatCharge"] = ToDbString(obj?.TotalVatCharge);
        row["TotalNetFedExCharge"] = ToDbString(obj?.TotalNetFedExCharge);
        row["TotalDutiesAndTaxes"] = ToDbString(obj?.TotalDutiesAndTaxes);

        row["NetTransportationAndPickupChargeAmount"] = ToDbString(obj?.TotalNetTransportationAndPickupCharge?.Amount);
        row["NetTransportationAndPickupChargeCurrency"] = ToDbString(obj?.TotalNetTransportationAndPickupCharge?.Currency);

        row["NetFedExTransportationAndPickupChargeAmount"] = ToDbString(obj?.TotalNetFedExTransportationAndPickupCharge?.Amount);
        row["NetFedExTransportationAndPickupChargeCurrency"] = ToDbString(obj?.TotalNetFedExTransportationAndPickupCharge?.Currency);

        // PickupRateDetail
        var prd = obj?.PickupRateDetail;
        row["PickupRateDetailRateType"] = ToDbString(prd?.RateType);
        row["PickupRateDetailRatingBasis"] = ToDbString(prd?.RatingBasis);
        row["PickupRateDetailPricingCode"] = ToDbString(prd?.PricingCode);
        row["PickupRateDetailFuelSurchargePercent"] = ToDbString(prd?.FuelSurchargePercent);

        // ShipmentRateDetail
        var srd = obj?.ShipmentRateDetail;

        row["TotalNetChargeWithDutiesAndTaxes"] = ToDbString(obj?.TotalNetChargeWithDutiesAndTaxes);
        row["TotalDutiesTaxesAndFees"] = ToDbString(obj?.TotalDutiesTaxesAndFees);
        row["TotalAncillaryFeesAndTaxes"] = ToDbString(obj?.TotalAncillaryFeesAndTaxes);

        row["RateZone"] = ToDbString(srd?.RateZone);
        row["DimDivisor"] = ToDbString(srd?.DimDivisor);
        row["FuelSurchargePercent"] = ToDbString(srd?.FuelSurchargePercent);
        row["TotalSurcharges"] = ToDbString(srd?.TotalSurcharges);
        row["TotalFreightDiscount"] = ToDbString(srd?.TotalFreightDiscount);
        row["PricingCode"] = ToDbString(srd?.PricingCode);

        row["FromCurrency"] = ToDbString(srd?.CurrencyExchangeRate?.FromCurrency);
        row["IntoCurrency"] = ToDbString(srd?.CurrencyExchangeRate?.IntoCurrency);
        row["Rate"] = ToDbString(srd?.CurrencyExchangeRate?.Rate);

        row["TotalBillingWeightUnits"] = ToDbString(srd?.TotalBillingWeight?.Units);
        row["TotalBillingWeightValue"] = ToDbString(srd?.TotalBillingWeight?.Value);

        row["ShipmentRateDetailCurrency"] = ToDbString(srd?.Currency);

        row["Currency"] = ToDbString(obj?.Currency);

        dt.Rows.Add(row);
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

    public static void CreateRow_Surcharge(DataTable dt, Surcharge surcharge, string customerTransactionId)
    {
        var row = dt.NewRow();

        row["CustomerTransactionId"] = ToDbString(customerTransactionId);
        row["Type"] = ToDbString(surcharge?.Type);
        row["Description"] = ToDbString(surcharge?.Description);
        row["Level"] = ToDbString(surcharge?.Level);

        // if Surcharge.Amount is decimal?
        row["Amount"] = (surcharge != null)
            ? (object)surcharge.Amount
            : DBNull.Value;

        dt.Rows.Add(row);
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


    public static void CreateRow_RatedPackage(DataTable dt, RatedPackage obj, string customerTransactionId)
    {
        var row = dt.NewRow();

        row["CustomerTransactionId"] = ToDbString(customerTransactionId);

        row["GroupNumber"] = ToDbString(obj?.GroupNumber);
        row["EffectiveNetDiscount"] = ToDbString(obj?.EffectiveNetDiscount);

        var prd = obj?.PackageRateDetail;

        row["RateType"] = ToDbString(prd?.RateType);
        row["RatedWeightMethod"] = ToDbString(prd?.RatedWeightMethod);
        row["BaseCharge"] = ToDbString(prd?.BaseCharge);
        row["NetFreight"] = ToDbString(prd?.NetFreight);
        row["TotalSurcharges"] = ToDbString(prd?.TotalSurcharges);
        row["NetFedExCharge"] = ToDbString(prd?.NetFedExCharge);
        row["TotalTaxes"] = ToDbString(prd?.TotalTaxes);
        row["NetCharge"] = ToDbString(prd?.NetCharge);
        row["TotalRebates"] = ToDbString(prd?.TotalRebates);

        // BillingWeight
        row["BillingWeightUnits"] = ToDbString(prd?.BillingWeight?.Units);
        row["BillingWeightValue"] = ToDbString(prd?.BillingWeight?.Value);

        row["TotalFreightDiscounts"] = ToDbString(prd?.TotalFreightDiscounts);
        row["Currency"] = ToDbString(prd?.Currency);

        dt.Rows.Add(row);
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

    public static void CreateRow_ServiceName(DataTable dt, ServiceName serviceName, string customerTransactionId)
    {
        var row = dt.NewRow();

        row["CustomerTransactionId"] = ToDbString(customerTransactionId);
        row["Type"] = ToDbString(serviceName?.Type);
        row["Encoding"] = ToDbString(serviceName?.Encoding);
        row["Value"] = ToDbString(serviceName?.Value);

        dt.Rows.Add(row);
    }


    // ----------------------------------------------------------
    // Create DataTable for Alerts
    // ----------------------------------------------------------
    public static DataTable CreateDT_Alert()
    {

        var dt = CreateBaseTable("ServiceName");

        dt.Columns.Add("CustomerTransactionId", typeof(string)); // Optional, link to parent
        dt.Columns.Add("Code", typeof(string));
        dt.Columns.Add("Message", typeof(string));
        dt.Columns.Add("AlertType", typeof(string));

        return dt;
    }

    // ----------------------------------------------------------
    // Create DataRow for Alerts
    // ----------------------------------------------------------
    public static void CreateRow_Alert(DataTable dt, Alert alert, string customerTransactionId = null)
    {
        var row = dt.NewRow();

        row["CustomerTransactionId"] = ToDbString(customerTransactionId) ;
        row["Code"] = ToDbString(alert?.Code) ;
        row["Message"] = ToDbString(alert?.Message) ;
        row["AlertType"] = ToDbString(alert?.AlertType);

        dt.Rows.Add(row);
    }


    private static object ToDbString(object value)
    {
        if (value == null)
            return DBNull.Value;

        string s = value.ToString();
        return string.IsNullOrWhiteSpace(s) ? DBNull.Value : (object)s;
    }


}
