using Newtonsoft.Json;

namespace NHodlHodl.Models;

public class Currency
{
    [JsonProperty("code")] public string Code { get; set; }
    [JsonProperty("name")] public string Name { get; set; }
    [JsonProperty("type")] public string Type { get; set; }
}