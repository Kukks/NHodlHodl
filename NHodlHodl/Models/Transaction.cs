using Newtonsoft.Json;

namespace NHodlHodl.Models;

public class Transaction
{
    [JsonProperty("contract_id")]
    public string ContractId { get; set; }

    [JsonProperty("hex")]
    public string Hex { get; set; }

    [JsonProperty("in_amounts")]
    public double[] InAmounts { get; set; }
}