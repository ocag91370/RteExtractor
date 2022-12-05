using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace RteExtractor.Consumption
{
    public class AnnualForecastResponse
    {
        [JsonPropertyName("annual_forecasts")]
        public List<AnnualForecast> Forecasts { get; set; }
    }
}
