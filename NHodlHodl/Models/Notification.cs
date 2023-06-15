using Newtonsoft.Json;

namespace NHodlHodl.Models;

public class Notification
{
    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("title")]
    public string Title { get; set; }

    [JsonProperty("body")]
    public string Body { get; set; }

    [JsonProperty("link")]
    public string Link { get; set; }
}