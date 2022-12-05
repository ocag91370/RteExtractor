using System.Text.Json.Serialization;

namespace RteExtractor
{
    public class Token
    {
        [JsonPropertyName("access_token")]
        public string Value { get; set; }

        [JsonPropertyName("token_type")]
        public string Type { get; set; }

        [JsonPropertyName("expires_in")]
        public int Delay { get; set; }

        [JsonPropertyName("scope")]
        public string Scope { get; set; }
    }
}
