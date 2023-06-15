using Newtonsoft.Json;

namespace NHodlHodl.Models;

public class Counterparty
{
    [JsonProperty("login")]
    public string Login { get; set; }

    [JsonProperty("avatar_url")]
    public string AvatarUrl { get; set; }

    [JsonProperty("online_status")]
    public string OnlineStatus { get; set; }

    [JsonProperty("rating")]
    public object Rating { get; set; }

    [JsonProperty("trades_count")]
    public int TradesCount { get; set; }

    [JsonProperty("url")]
    public string Url { get; set; }

    [JsonProperty("verified")]
    public bool Verified { get; set; }

    [JsonProperty("verified_by")]
    public object VerifiedBy { get; set; }

    [JsonProperty("strong_hodler")]
    public bool StrongHodler { get; set; }

    [JsonProperty("country")]
    public string Country { get; set; }

    [JsonProperty("country_code")]
    public string CountryCode { get; set; }

    [JsonProperty("average_payment_time_minutes")]
    public object AveragePaymentTimeMinutes { get; set; }

    [JsonProperty("average_release_time_minutes")]
    public object AverageReleaseTimeMinutes { get; set; }

    [JsonProperty("days_since_last_trade")]
    public object DaysSinceLastTrade { get; set; }

    [JsonProperty("blocked_by")]
    public int BlockedBy { get; set; }
}