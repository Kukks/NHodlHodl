using Newtonsoft.Json;

namespace NHodlHodl.Models;

public class Contract
{
    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("your_role")]
    public string YourRole { get; set; }

    [JsonProperty("can_be_canceled")]
    public bool CanBeCanceled { get; set; }

    [JsonProperty("offer_id")]
    public string OfferId { get; set; }

    [JsonProperty("price")]
    public string Price { get; set; }

    [JsonProperty("value")]
    public string Value { get; set; }

    [JsonProperty("currency_code")]
    public string CurrencyCode { get; set; }

    [JsonProperty("volume")]
    public string Volume { get; set; }

    [JsonProperty("asset_code")]
    public string AssetCode { get; set; }

    [JsonProperty("comment")]
    public string Comment { get; set; }

    [JsonProperty("confirmations")]
    public int Confirmations { get; set; }

    [JsonProperty("payment_window_seconds_left")]
    public object PaymentWindowSecondsLeft { get; set; }

    [JsonProperty("payment_window_time_left_seconds")]
    public object PaymentWindowTimeLeftSeconds { get; set; }

    [JsonProperty("payment_window_minutes")]
    public int PaymentWindowMinutes { get; set; }

    [JsonProperty("depositing_window_minutes")]
    public int DepositingWindowMinutes { get; set; }

    [JsonProperty("depositing_window_time_left_seconds")]
    public object DepositingWindowTimeLeftSeconds { get; set; }

    [JsonProperty("status")]
    public string Status { get; set; }

    [JsonProperty("dispute_status")]
    public object DisputeStatus { get; set; }

    [JsonProperty("payment_method_instruction")]
    public PaymentMethodInstructionObj PaymentMethodInstruction { get; set; }

    [JsonProperty("volume_breakdown")]
    public VolumeBreakdown VolumeBreakdown { get; set; }

    [JsonProperty("country")]
    public string Country { get; set; }

    [JsonProperty("country_code")]
    public string CountryCode { get; set; }

    [JsonProperty("created_at")]
    public string CreatedAt { get; set; }

    [JsonProperty("counterparty")]
    public Counterparty Counterparty { get; set; }

    [JsonProperty("escrow")]
    public Escrow Escrow { get; set; }
    
    public class PaymentMethodInstructionObj
    {
        [JsonProperty("payment_method_id")]
        public string PaymentMethodId { get; set; }

        [JsonProperty("details")]
        public string Details { get; set; }
    }
}