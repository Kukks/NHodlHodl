using Newtonsoft.Json;

namespace NHodlHodl.Models;

public class Fee
{
    [JsonProperty("author_fee_rate")]
    public string AuthorFeeRate { get; set; }

    [JsonProperty("intermediary_fee_rate")]
    public string IntermediaryFeeRate { get; set; }

    [JsonProperty("your_fee_rate")]
    public string YourFeeRate { get; set; }

    [JsonProperty("transaction_fee")]
    public string TransactionFee { get; set; }

    [JsonProperty("exchange_fee")]
    public string ExchangeFee { get; set; }
    
   
}