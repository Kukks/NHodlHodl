using Newtonsoft.Json;

namespace NHodlHodl.Models;

public class PaymentMethodInstructionRequest
{
    public class Item
    {
        [JsonProperty("payment_method_id")]
        public string PaymentMethodId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("details")]
        public string Details { get; set; }
    }

    [JsonProperty("payment_method_instruction")]
    public Item PaymentMethodInstruction { get; set; }
}