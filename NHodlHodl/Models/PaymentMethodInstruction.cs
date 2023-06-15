using Newtonsoft.Json;

namespace NHodlHodl.Models;

public class PaymentMethodInstruction
{
    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("version")]
    public string Version { get; set; }

    [JsonProperty("payment_method_id")]
    public string PaymentMethodId { get; set; }

    [JsonProperty("payment_method_type")]
    public string PaymentMethodType { get; set; }

    [JsonProperty("payment_method_name")]
    public string PaymentMethodName { get; set; }

    [JsonProperty("details")]
    public string Details { get; set; }
}