using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace RteExtractor.Consumption
{
    public class WeeklyForecast
    {
        [JsonPropertyName("start_date")]
        public DateTime StartDate { get; set; }

        [JsonPropertyName("end_date")]
        public DateTime EndDate { get; set; }

        [JsonPropertyName("updated_date")]
        public DateTime UpdatedDate { get; set; }

        [JsonPropertyName("peak")]
        public WeeklyForecastPeak Peak { get; set; }

        [JsonPropertyName("values")]
        public List<WeeklyForecastValue> Values{ get; set; }
    }
}