using Newtonsoft.Json;

namespace NHodlHodl.Models;

public class PaymentMethodInstructionsResponse : Response
{
    [JsonProperty("payment_method_instructions")]
    public PaymentMethodInstruction[] PaymentMethodInstructions { get; set; }
}