using Newtonsoft.Json;

namespace NHodlHodl.Models;

public class ExchangeRatePriceResponse
{
    [JsonProperty("status")]
    public string Status { get; set; }

    [JsonProperty("price")]
    public decimal Price { get; set; }
}