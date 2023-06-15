using Newtonsoft.Json;

namespace NHodlHodl.Models;

public class CurrenciesResponse : Response
{
    [JsonProperty("currencies")] public Currency[] Currencies { get; set; }
}