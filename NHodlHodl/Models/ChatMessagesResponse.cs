using Newtonsoft.Json;

namespace NHodlHodl.Models;

public class ChatMessagesResponse : Response
{
    [JsonProperty("chat_messages")]
    public List<ChatMessage> ChatMessages { get; set; }
}