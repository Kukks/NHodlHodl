using Newtonsoft.Json;

namespace NHodlHodl.Models;

public class UserResponse : Response
{
    [JsonProperty("user")]
    public User User { get; set; }
}