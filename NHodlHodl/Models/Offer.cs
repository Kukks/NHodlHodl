using Newtonsoft.Json;

namespace NHodlHodl.Models;

public class Offer
{
    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("version")]
    public string Version { get; set; }

    [JsonProperty("asset_code")]
    public string AssetCode { get; set; }

    [JsonProperty("searchable")]
    public bool Searchable { get; set; }

    [JsonProperty("country")]
    public string Country { get; set; }

    [JsonProperty("country_code")]
    public string CountryCode { get; set; }

    [JsonProperty("working_now")]
    public bool WorkingNow { get; set; }

    [JsonProperty("side")]
    public string Side { get; set; }

    [JsonProperty("title")]
    public string Title { get; set; }

    [JsonProperty("description")]
    public string Description { get; set; }

    [JsonProperty("currency_code")]
    public string CurrencyCode { get; set; }

    [JsonProperty("price")]
    public string Price { get; set; }

    [JsonProperty("min_amount")]
    public string MinAmount { get; set; }

    [JsonProperty("max_amount")]
    public string MaxAmount { get; set; }

    [JsonProperty("first_trade_limit")]
    public object FirstTradeLimit { get; set; }

    [JsonProperty("fee")]
    public Fee Fee { get; set; }

    [JsonProperty("balance")]
    public object Balance { get; set; }

    [JsonProperty("payment_window_minutes")]
    public int PaymentWindowMinutes { get; set; }

    [JsonProperty("confirmations")]
    public int Confirmations { get; set; }

    [JsonProperty("payment_method_instructions")]
    public PaymentMethodInstruction[] PaymentMethodInstructions { get; set; }

    [JsonProperty("trader")]
    public Trader Trader { get; set; }
}