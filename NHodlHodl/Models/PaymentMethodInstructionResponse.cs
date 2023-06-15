using Newtonsoft.Json;

namespace NHodlHodl.Models;

public class PaymentMethodInstructionResponse : Response
{
    [JsonProperty("payment_method_instruction")]
    public PaymentMethodInstruction PaymentMethodInstruction { get; set; }
}