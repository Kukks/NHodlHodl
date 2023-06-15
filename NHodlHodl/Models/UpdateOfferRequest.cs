using Newtonsoft.Json;

namespace NHodlHodl.Models;

public class UpdateOfferRequest
{
    
    public class OfferData
    {
        [JsonProperty("side", NullValueHandling = NullValueHandling.Ignore)]
        public string Side { get; set; }

        [JsonProperty("country_code", NullValueHandling = NullValueHandling.Ignore)]
        public string CountryCode { get; set; }

        [JsonProperty("balance", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? Balance { get; set; }

        [JsonProperty("min_amount", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? MinAmount { get; set; }

        [JsonProperty("max_amount", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? MaxAmount { get; set; }

        [JsonProperty("first_trade_limit", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? FirstTradeLimit { get; set; }

        [JsonProperty("stop_loss_value", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? StopLossValue { get; set; }

        [JsonProperty("for_experienced_users", NullValueHandling = NullValueHandling.Ignore)]
        public bool? ForExperiencedUsers { get; set; }

        [JsonProperty("confirmations", NullValueHandling = NullValueHandling.Ignore)]
        public int? Confirmations { get; set; }

        [JsonProperty("payment_window_minutes", NullValueHandling = NullValueHandling.Ignore)]
        public int? PaymentWindowMinutes { get; set; }

        [JsonProperty("workdays_only", NullValueHandling = NullValueHandling.Ignore)]
        public bool? WorkdaysOnly { get; set; }

        [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get; set; }

        [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }

        [JsonProperty("enabled", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Enabled { get; set; }

        [JsonProperty("private", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Private { get; set; }

        [JsonProperty("payment_method_ids", NullValueHandling = NullValueHandling.Ignore)]
        public int[] PaymentMethodIds { get; set; }

        [JsonProperty("payment_method_instruction_ids", NullValueHandling = NullValueHandling.Ignore)]
        public int[] PaymentMethodInstructionIds { get; set; }

        [JsonProperty("working_hours_start_in_timezone", NullValueHandling = NullValueHandling.Ignore)]
        public string WorkingHoursStartInTimezone { get; set; }

        [JsonProperty("working_hours_end_in_timezone", NullValueHandling = NullValueHandling.Ignore)]
        public string WorkingHoursEndInTimezone { get; set; }

        [JsonProperty("timezone", NullValueHandling = NullValueHandling.Ignore)]
        public string Timezone { get; set; }

        [JsonProperty("working_hours_start_utc", NullValueHandling = NullValueHandling.Ignore)]
        public string WorkingHoursStartUtc { get; set; }

        [JsonProperty("working_hours_end_utc", NullValueHandling = NullValueHandling.Ignore)]
        public string WorkingHoursEndUtc { get; set; }

        [JsonProperty("price_source", NullValueHandling = NullValueHandling.Ignore)]
        public string PriceSource { get; set; }

        [JsonProperty("price", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? Price { get; set; }

        [JsonProperty("exchange_rate_provider", NullValueHandling = NullValueHandling.Ignore)]
        public string ExchangeRateProvider { get; set; }

        [JsonProperty("exchange_price_deviation", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? ExchangePriceDeviation { get; set; }

        [JsonProperty("exchange_price_sign", NullValueHandling = NullValueHandling.Ignore)]
        public string ExchangePriceSign { get; set; }

        [JsonProperty("exchange_price_unit", NullValueHandling = NullValueHandling.Ignore)]
        public string ExchangePriceUnit { get; set; }

        [JsonProperty("currency_code", NullValueHandling = NullValueHandling.Ignore)]
        public string CurrencyCode { get; set; }
    }
    [JsonProperty("offer")]
    public OfferData Offer { get; set; }
}