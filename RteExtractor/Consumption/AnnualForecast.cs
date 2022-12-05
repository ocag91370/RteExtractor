using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace RteExtractor.Consumption
{
    public class AnnualForecast
    {
        [JsonPropertyName("start_date")]
        public DateTime StartDate { get; set; }

        [JsonPropertyName("end_date")]
        public DateTime EndDate { get; set; }

        [JsonPropertyName("values")]
        public List<AnnualForecastValue> Values{ get; set; }
    }
}