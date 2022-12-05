using System;
using System.Text.Json.Serialization;

namespace RteExtractor.Consumption
{
    public class AnnualForecastValue
    {
        [JsonPropertyName("start_date")]
        public DateTime StartDate { get; set; }

        [JsonPropertyName("end_date")]
        public DateTime EndDate { get; set; }

        [JsonPropertyName("average_load_saturday_to_friday")]
        public int AverageLoadSaturdayToFriday { get; set; }

        [JsonPropertyName("average_load_monday_to_sunday")]
        public int AverageLoadMondayToSunday { get; set; }

        [JsonPropertyName("weekly_minimum")]
        public int WeeklyMinimum { get; set; }

        [JsonPropertyName("weekly_maximum")]
        public int WeeklyMaximum { get; set; }

        [JsonPropertyName("average_load_updated_date")]
        public DateTime AverageLoadUpdatedDate { get; set; }

        [JsonPropertyName("margin_updated_date")]
        public DateTime MarginUpdatedDate { get; set; }

        [JsonPropertyName("forecast_margin")]
        public int ForecastMargin { get; set; }
    }
}