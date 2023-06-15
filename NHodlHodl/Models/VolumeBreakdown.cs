using Newtonsoft.Json;

namespace NHodlHodl.Models;

public class VolumeBreakdown
{
    [JsonProperty("goes_to_buyer")]
    public string GoesToBuyer { get; set; }

    [JsonProperty("exchange_fee")]
    public string ExchangeFee { get; set; }

    [JsonProperty("exchange_fee_in_fiat")]
    public string ExchangeFeeInFiat { get; set; }

    [JsonProperty("transaction_fee")]
    public string TransactionFee { get; set; }
}