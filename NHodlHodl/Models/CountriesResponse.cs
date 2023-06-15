using Newtonsoft.Json;

namespace NHodlHodl.Models;

public class CountriesResponse : Response
{
    [JsonProperty("countries")] public Country[] Countries { get; set; }
}