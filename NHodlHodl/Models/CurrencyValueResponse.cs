using Newtonsoft.Json;

namespace NHodlHodl.Models;

public class CurrencyValueResponse
{
    [JsonProperty("currency_code")]
    public string CurrencyCode { get; set; }

    [JsonProperty("value")]
    public decimal Value { get; set; }
}