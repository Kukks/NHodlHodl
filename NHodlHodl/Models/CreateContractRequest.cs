using Newtonsoft.Json;

namespace NHodlHodl.Models;

public class CreateContractRequest
{
    [JsonProperty("contract")]
    public CreateContract Contract { get; set; }

    [JsonProperty("nonce")]
    public string Nonce { get; set; }

    [JsonProperty("hmac")]
    public string Hmac { get; set; }

    public class CreateContract
    {
        [JsonProperty("offer_id")]
        public string OfferId { get; set; }

        [JsonProperty("offer_version")]
        public string OfferVersion { get; set; }

        [JsonProperty("payment_method_instruction_id")]
        public int PaymentMethodInstructionId { get; set; }

        [JsonProperty("payment_method_instruction_version")]
        public string PaymentMethodInstructionVersion { get; set; }

        [JsonProperty("comment")]
        public string Comment { get; set; }

        [JsonProperty("value")]
        public decimal Value { get; set; }

        [JsonProperty("volume")]
        public int Volume { get; set; }

        [JsonProperty("release_address")]
        public string ReleaseAddress { get; set; }
    }
}