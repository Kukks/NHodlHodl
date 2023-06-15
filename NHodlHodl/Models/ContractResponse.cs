using Newtonsoft.Json;

namespace NHodlHodl.Models;

public class ContractResponse : Response
{
    [JsonProperty("contract")]
    public Contract Contract { get; set; }
}