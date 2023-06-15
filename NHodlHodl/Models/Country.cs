using Newtonsoft.Json;

namespace NHodlHodl.Models;

public class Country
{
    [JsonProperty("code")] public string Code { get; set; }
    [JsonProperty("name")] public string Name { get; set; }
    [JsonProperty("native_name")] public string NativeName { get; set; }
    [JsonProperty("currency_code")] public string CurrencyCode { get; set; }
    [JsonProperty("currency_name")] public string CurrencyName { get; set; }
}