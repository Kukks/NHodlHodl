using Newtonsoft.Json;

namespace NHodlHodl.Models;

public class ExchangeRateProvider
{
    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("currency_codes")]
    public string[] CurrencyCodes { get; set; }
}