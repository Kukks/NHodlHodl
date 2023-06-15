using Newtonsoft.Json;

namespace NHodlHodl.Models;

public class Response
{
    [JsonProperty("status")] public string Status { get; set; }
}