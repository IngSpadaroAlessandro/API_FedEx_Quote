using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using static API_FedEx_Quote.StoredProcedure;

namespace API_FedEx_Quote
{
    public class ResponseObjectToken
    {
        public string token_type { get; set; }
        public long issued_at { get; set; }
        public string client_id { get; set; }
        public string access_token { get; set; }
        public int expires_in { get; set; }
        public string status { get; set; }
    }

    public class ApiError
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }

    public class FedExRateResponse
    {
        [JsonProperty("transactionId")]
        public string TransactionId { get; set; }

        [JsonProperty("customerTransactionId")]
        public string CustomerTransactionId { get; set; }

        [JsonProperty("output")]
        public FedExOutput Output { get; set; }

        [JsonProperty("errors")]
        public List<ApiError> Errors { get; set; }
    }

    public class FedExOutput
    {
        [JsonProperty("rateReplyDetails")]
        [JsonConverter(typeof(SingleOrArrayConverter<RateReplyDetail>))]
        public List<RateReplyDetail> RateReplyDetails { get; set; }
        public string QuoteDate { get; set; }
        public bool Encoded { get; set; }
    }

    public class RateReplyDetail
    {
        [JsonProperty("serviceType")]
        public string ServiceType { get; set; }

        [JsonProperty("serviceName")]
        public string ServiceName { get; set; }

        [JsonProperty("packagingType")]
        public string PackagingType { get; set; }

        [JsonProperty("customerMessages")]
        [JsonConverter(typeof(SingleOrArrayConverter<CustomerMessage>))]
        public List<CustomerMessage> CustomerMessages { get; set; }

        [JsonProperty("ratedShipmentDetails")]
        [JsonConverter(typeof(SingleOrArrayConverter<RatedShipmentDetail>))]
        public List<RatedShipmentDetail> RatedShipmentDetails { get; set; }

        [JsonProperty("anonymouslyAllowable")]
        public bool AnonymouslyAllowable { get; set; }

        [JsonProperty("operationalDetail")]
        public OperationalDetail OperationalDetail { get; set; }

        [JsonProperty("signatureOptionType")]
        public string SignatureOptionType { get; set; }

        [JsonProperty("serviceDescription")]
        public ServiceDescription ServiceDescription { get; set; }

        [JsonProperty("commit")]
        public Commit Commit { get; set; }
    }

    public class CustomerMessage
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }

    public class RatedShipmentDetail
    {
        [JsonProperty("rateType")]
        public string RateType { get; set; }

        [JsonProperty("ratedWeightMethod")]
        public string RatedWeightMethod { get; set; }

        [JsonProperty("totalDiscounts")]
        public decimal TotalDiscounts { get; set; }

        [JsonProperty("totalBaseCharge")]
        public decimal TotalBaseCharge { get; set; }

        [JsonProperty("totalNetCharge")]
        public decimal TotalNetCharge { get; set; }

        [JsonProperty("totalVatCharge")]
        public decimal TotalVatCharge { get; set; }

        [JsonProperty("totalNetFedExCharge")]
        public decimal TotalNetFedExCharge { get; set; }

        [JsonProperty("totalDutiesAndTaxes")]
        public decimal TotalDutiesAndTaxes { get; set; }

        [JsonProperty("totalNetTransportationAndPickupCharge")]
        public Money TotalNetTransportationAndPickupCharge { get; set; }

        [JsonProperty("totalNetFedExTransportationAndPickupCharge")]
        public Money TotalNetFedExTransportationAndPickupCharge { get; set; }

        [JsonProperty("pickupRateDetail")]
        public PickupRateDetail PickupRateDetail { get; set; }

        [JsonProperty("totalNetChargeWithDutiesAndTaxes")]
        public decimal TotalNetChargeWithDutiesAndTaxes { get; set; }

        [JsonProperty("totalDutiesTaxesAndFees")]
        public decimal TotalDutiesTaxesAndFees { get; set; }

        [JsonProperty("totalAncillaryFeesAndTaxes")]
        public decimal TotalAncillaryFeesAndTaxes { get; set; }

        [JsonProperty("shipmentRateDetail")]
        public ShipmentRateDetail ShipmentRateDetail { get; set; }


        [JsonProperty("ratedPackages")]
        [JsonConverter(typeof(SingleOrArrayConverter<RatedPackage>))]
        public List<RatedPackage> RatedPackages { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }
    }

    public class Money
    {
        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }
    }
    public class PickupRateDetail
    {
        [JsonProperty("rateType")]
        public string RateType { get; set; }

        [JsonProperty("ratingBasis")]
        public string RatingBasis { get; set; }

        [JsonProperty("pricingCode")]
        public string PricingCode { get; set; }

        [JsonProperty("fuelSurchargePercent")]
        public decimal FuelSurchargePercent { get; set; }
    }

    public class ShipmentRateDetail
    {
        [JsonProperty("rateZone")]
        public string RateZone { get; set; }

        [JsonProperty("dimDivisor")]
        public decimal DimDivisor { get; set; }

        [JsonProperty("fuelSurchargePercent")]
        public decimal FuelSurchargePercent { get; set; }

        [JsonProperty("totalSurcharges")]
        public decimal TotalSurcharges { get; set; }

        [JsonProperty("totalFreightDiscount")]
        public decimal TotalFreightDiscount { get; set; }

        [JsonProperty("surCharges")]
        [JsonConverter(typeof(SingleOrArrayConverter<Surcharge>))]
        public List<Surcharge> SurCharges { get; set; }

        [JsonProperty("pricingCode")]
        public string PricingCode { get; set; }

        [JsonProperty("currencyExchangeRate")]
        public CurrencyExchangeRate CurrencyExchangeRate { get; set; }

        [JsonProperty("totalBillingWeight")]
        public TotalBillingWeight TotalBillingWeight { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }
    }

    public class Surcharge
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("level")]
        public string Level { get; set; }

        [JsonProperty("amount")]
        public decimal Amount { get; set; }
    }

    public class CurrencyExchangeRate
    {
        [JsonProperty("fromCurrency")]
        public string FromCurrency { get; set; }

        [JsonProperty("intoCurrency")]
        public string IntoCurrency { get; set; }

        [JsonProperty("rate")]
        public decimal Rate { get; set; }
    }

    public class TotalBillingWeight
    {
        [JsonProperty("units")]
        public string Units { get; set; }

        [JsonProperty("value")]
        public decimal Value { get; set; }
    }

    public class RatedPackage
    {
        [JsonProperty("groupNumber")]
        public int GroupNumber { get; set; }

        [JsonProperty("effectiveNetDiscount")]
        public decimal EffectiveNetDiscount { get; set; }

        [JsonProperty("packageRateDetail")]
        public PackageRateDetail PackageRateDetail { get; set; }
    }

    public class PackageRateDetail
    {
        [JsonProperty("rateType")]
        public string RateType { get; set; }

        [JsonProperty("ratedWeightMethod")]
        public string RatedWeightMethod { get; set; }

        [JsonProperty("baseCharge")]
        public decimal BaseCharge { get; set; }

        [JsonProperty("netFreight")]
        public decimal NetFreight { get; set; }

        [JsonProperty("totalSurcharges")]
        public decimal TotalSurcharges { get; set; }

        [JsonProperty("netFedExCharge")]
        public decimal NetFedExCharge { get; set; }

        [JsonProperty("totalTaxes")]
        public decimal TotalTaxes { get; set; }

        [JsonProperty("netCharge")]
        public decimal NetCharge { get; set; }

        [JsonProperty("totalRebates")]
        public decimal TotalRebates { get; set; }

        [JsonProperty("billingWeight")]
        public TotalBillingWeight BillingWeight { get; set; }

        [JsonProperty("totalFreightDiscounts")]
        public decimal TotalFreightDiscounts { get; set; }

        [JsonProperty("surcharges")]
        [JsonConverter(typeof(SingleOrArrayConverter<Surcharge>))]
        public List<Surcharge> Surcharges { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }
    }

    public class OperationalDetail
    {
        [JsonProperty("originLocationIds")]
        public string OriginLocationIds { get; set; }

        [JsonProperty("serviceCode")]
        public string ServiceCode { get; set; }

        [JsonProperty("airportId")]
        public string AirportId { get; set; }

        [JsonProperty("astraDescription")]
        public string AstraDescription { get; set; }

        [JsonProperty("destinationPostalCode")]
        public string DestinationPostalCode { get; set; }

        [JsonProperty("commitDate")]
        public DateTimeOffset? CommitDate { get; set; }

        [JsonProperty("transitTime")]
        public string TransitTime { get; set; }

        [JsonProperty("destinationLocationIds")]
        public string DestinationLocationIds { get; set; }

        [JsonProperty("stateOrProvinceCodes")]
        public string StateOrProvinceCodes { get; set; }

        [JsonProperty("countryCodes")]
        public string CountryCodes { get; set; }
    }

    public class ServiceDescription
    {
        [JsonProperty("serviceId")]
        public string ServiceId { get; set; }

        [JsonProperty("serviceType")]
        public string ServiceType { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("names")]
        [JsonConverter(typeof(SingleOrArrayConverter<ServiceName>))]
        public List<ServiceName> Names { get; set; }

        [JsonProperty("operatingOrgCodes")]
        public List<string> OperatingOrgCodes { get; set; }

        [JsonProperty("serviceCategory")]
        public string ServiceCategory { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("astraDescription")]
        public string AstraDescription { get; set; }
    }

    public class ServiceName
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("encoding")]
        public string Encoding { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }

    public class Commit
    {
        [JsonProperty("dateDetail")]
        public DateDetail DateDetail { get; set; }
    }

    public class DateDetail
    {
        [JsonProperty("dayOfWeek")]
        public string DayOfWeek { get; set; }

        [JsonProperty("dayCxsFormat")]
        public string DayCxsFormat { get; set; }
    }

}
