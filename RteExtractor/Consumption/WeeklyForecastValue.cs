using System;
using System.Text.Json.Serialization;

namespace RteExtractor.Consumption
{
    public class WeeklyForecastValue
    {
        [JsonPropertyName("start_date")]
        public DateTime StartDate { get; set; }

        [JsonPropertyName("end_date")]
        public DateTime EndDate { get; set; }

        [JsonPropertyName("value")]
        public int Value { get; set; }
    }
}