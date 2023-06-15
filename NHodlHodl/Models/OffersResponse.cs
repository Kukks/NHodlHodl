using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace NHodlHodl.Models;

public class OffersResponse : Response
{
    [JsonProperty("offers")]
    public Offer[] Offers { get; set; }

    [JsonExtensionData]
    private IDictionary<string, JToken> AdditionalData { get; set; }
}