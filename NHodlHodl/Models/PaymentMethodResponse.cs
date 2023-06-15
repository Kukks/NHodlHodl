using Newtonsoft.Json;

namespace NHodlHodl.Models;

public class PaymentMethodResponse : Response
{
    [JsonProperty("filters")] public Dictionary<string, string> Filters { get; set; }
    [JsonProperty("payment_methods")] public PaymentMethod[] PaymentMethods { get; set; }
}