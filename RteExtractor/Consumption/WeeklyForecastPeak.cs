using System;
using System.Text.Json.Serialization;

namespace RteExtractor.Consumption
{
    public class WeeklyForecastPeak
    {

        [JsonPropertyName("peak_hour")]
        public DateTime Hour { get; set; }

        [JsonPropertyName("value")]
        public int Value { get; set; }

        [JsonPropertyName("temperature")]
        public float Temperature { get; set; }

        [JsonPropertyName("temperature_deviation")]
        public float TemperatureDeviation { get; set; }
    }
}