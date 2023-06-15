using Newtonsoft.Json;

namespace NHodlHodl.Models;

public class CreateOfferRequest
{
    [JsonProperty("offer")]
    public OfferData Offer { get; set; }
}