using Newtonsoft.Json;

namespace NHodlHodl.Models;

public class NotificationsResponse : Response
{
    [JsonProperty("notifications")]
    public Notification[] Notifications { get; set; }
}