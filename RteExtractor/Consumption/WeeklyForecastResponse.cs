using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace RteExtractor.Consumption
{
    public class WeeklyForecastResponse
    {
        [JsonPropertyName("weekly_forecasts")]
        public List<WeeklyForecast> Forecasts { get; set; }
    }
}
