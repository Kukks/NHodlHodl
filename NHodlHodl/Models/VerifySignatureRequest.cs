using Newtonsoft.Json;

namespace NHodlHodl.Models;

public class VerifySignatureRequest
{
    [JsonProperty("nonce")]
    public string Nonce { get; set; }

    [JsonProperty("hmac")]
    public string Hmac { get; set; }
}