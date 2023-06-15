using Newtonsoft.Json;

namespace NHodlHodl.Models;

public class OfferData
{
    [JsonProperty("asset_code")]
    public string AssetCode { get; set; }

    [JsonProperty("side")]
    public string Side { get; set; }

    [JsonProperty("country_code")]
    public string CountryCode { get; set; }

    [JsonProperty("currency_code")]
    public string CurrencyCode { get; set; }

    [JsonProperty("balance")]
    public decimal? Balance { get; set; }

    [JsonProperty("min_amount")]
    public decimal MinAmount { get; set; }

    [JsonProperty("max_amount")]
    public decimal MaxAmount { get; set; }

    [JsonProperty("first_trade_limit")]
    public decimal? FirstTradeLimit { get; set; }

    [JsonProperty("stop_loss_value")]
    public decimal? StopLossValue { get; set; }

    [JsonProperty("for_experienced_users")]
    public bool? ForExperiencedUsers { get; set; }

    [JsonProperty("confirmations")]
    public int Confirmations { get; set; }

    [JsonProperty("payment_window_minutes")]
    public int PaymentWindowMinutes { get; set; }

    [JsonProperty("workdays_only")]
    public bool WorkdaysOnly { get; set; }

    [JsonProperty("title")]
    public string Title { get; set; }

    [JsonProperty("description")]
    public string Description { get; set; }

    [JsonProperty("enabled")]
    public bool Enabled { get; set; }

    [JsonProperty("private")]
    public bool Private { get; set; }

    [JsonProperty("payment_method_ids")]
    public int[] PaymentMethodIds { get; set; }

    [JsonProperty("payment_method_instruction_ids")]
    public int[] PaymentMethodInstructionIds { get; set; }

    [JsonProperty("working_hours_start_in_timezone")]
    public string WorkingHoursStartInTimezone { get; set; }

    [JsonProperty("working_hours_end_in_timezone")]
    public string WorkingHoursEndInTimezone { get; set; }

    [JsonProperty("timezone")]
    public string Timezone { get; set; }

    [JsonProperty("working_hours_start_utc")]
    public string WorkingHoursStartUtc { get; set; }

    [JsonProperty("working_hours_end_utc")]
    public string WorkingHoursEndUtc { get; set; }

    [JsonProperty("price_source")]
    public string PriceSource { get; set; }

    [JsonProperty("price")]
    public decimal? Price { get; set; }

    [JsonProperty("exchange_rate_provider")]
    public string ExchangeRateProvider { get; set; }

    [JsonProperty("exchange_price_deviation")]
    public decimal? ExchangePriceDeviation { get; set; }

    [JsonProperty("exchange_price_sign")]
    public string ExchangePriceSign { get; set; }

    [JsonProperty("exchange_price_unit")]
    public string ExchangePriceUnit { get; set; }
}