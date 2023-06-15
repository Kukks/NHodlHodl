using Newtonsoft.Json;

namespace NHodlHodl.Models;

public class PaymentMethod
{
    [JsonProperty("id")] public string Id { get; set; }
    [JsonProperty("country_codes")] public string[] Codes { get; set; }
    [JsonProperty("name")] public string Name { get; set; }
    [JsonProperty("type")] public string Type { get; set; }
    [JsonProperty("description")] public string Description { get; set; }
    [JsonProperty("discounted")] public bool Discounted { get; set; }
    [JsonProperty("global")] public bool Global { get; set; }
}