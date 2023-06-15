using Newtonsoft.Json;

namespace NHodlHodl.Models;

public class SignTransactionRequest
{
    [JsonProperty("hex")]
    public string Hex { get; set; }
}