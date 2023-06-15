using Newtonsoft.Json;

namespace NHodlHodl.Models;

public class Escrow
{
    [JsonProperty("address")]
    public object Address { get; set; }

    [JsonProperty("witness_script")]
    public object WitnessScript { get; set; }

    [JsonProperty("index")]
    public object Index { get; set; }

    [JsonProperty("you_confirmed")]
    public bool YouConfirmed { get; set; }

    [JsonProperty("counterparty_confirmed")]
    public bool CounterpartyConfirmed { get; set; }

    [JsonProperty("confirmations")]
    public int Confirmations { get; set; }

    [JsonProperty("amount_deposited")]
    public object AmountDeposited { get; set; }

    [JsonProperty("amount_released")]
    public object AmountReleased { get; set; }

    [JsonProperty("deposit_transaction_id")]
    public object DepositTransactionId { get; set; }

    [JsonProperty("release_transaction_id")]
    public object ReleaseTransactionId { get; set; }
}