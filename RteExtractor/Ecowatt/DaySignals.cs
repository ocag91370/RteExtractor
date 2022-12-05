using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace RteExtractor.Ecowatt
{
    public class DaySignals
    {
        [JsonPropertyName("GenerationFichier")]
        public DateTime FileDay { get; set; }

        [JsonPropertyName("jour")]
        public DateTime Day { get; set; }

        [JsonPropertyName("dvalue")]
        public int Value { get; set; }

        [JsonPropertyName("message")]
        public string Message { get; set; }

        [JsonPropertyName("values")]
        public List<HourSignal> Values { get; set; }
    }
}
