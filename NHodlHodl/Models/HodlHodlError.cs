using Newtonsoft.Json;

namespace NHodlHodl.Models;

public class HodlHodlError : Response
{
    [JsonProperty("error_code")] public string ErrorCode { get; set; }
    [JsonProperty("parameter")] public string? Parameter { get; set; }
    [JsonProperty("validation_errors")] public Dictionary<string, string[]>? ValidationErrors { get; set; }
}