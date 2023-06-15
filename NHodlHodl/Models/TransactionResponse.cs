using Newtonsoft.Json;

namespace NHodlHodl.Models;

public class TransactionResponse : Response
{
    [JsonProperty("transaction")]
    public Transaction Transaction { get; set; }
}