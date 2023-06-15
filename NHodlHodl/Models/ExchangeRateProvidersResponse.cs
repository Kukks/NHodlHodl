using Newtonsoft.Json;

namespace NHodlHodl.Models;

public class ExchangeRateProvidersResponse : Response
{
    [JsonProperty("exchange_rate_providers")]
    public ExchangeRateProvider[] ExchangeRateProviders { get; set; }
}