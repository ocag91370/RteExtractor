using System.Text.Json.Serialization;

namespace RteExtractor.Ecowatt
{
    public class HourSignal
    {
        [JsonPropertyName("pas")]
        public int Hour { get; set; }

        [JsonPropertyName("hvalue")]
        public int Value { get; set; }
    }
}
