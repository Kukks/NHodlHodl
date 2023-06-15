using Newtonsoft.Json;

namespace NHodlHodl.Models;

public class TimezonesResponse : Response
{
    [JsonProperty("timezones")] public Timezone[] Timezones { get; set; }
}