using Newtonsoft.Json;

namespace NHodlHodl.Models;

public class ContractsResponse : Response
{
    [JsonProperty("contracts")]
    public Contract[] Contracts { get; set; }
}