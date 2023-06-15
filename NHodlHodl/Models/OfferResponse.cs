using Newtonsoft.Json;

namespace NHodlHodl.Models;

public class OfferResponse : Response
{
    [JsonProperty("offer")]
    public Offer Offer { get; set; }
}