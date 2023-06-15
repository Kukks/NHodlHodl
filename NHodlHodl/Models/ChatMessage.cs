using Newtonsoft.Json;

namespace NHodlHodl.Models;

public class ChatMessage
{
    [JsonProperty("text")]
    public string Text { get; set; }
    [JsonProperty("author")]
    public string Author { get; set; }
    [JsonProperty("from_admin")]
    public bool FromAdmin { get; set; }
    [JsonProperty("sent_at")]
    public DateTimeOffset SentAt { get; set; }
}