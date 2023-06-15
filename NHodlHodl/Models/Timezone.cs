using Newtonsoft.Json;

namespace NHodlHodl.Models;

public class Timezone
{
    [JsonProperty("name")] public string Name { get; set; }
    [JsonProperty("gmt_offset")] public string Offset { get; set; }
}