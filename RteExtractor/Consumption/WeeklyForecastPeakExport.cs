using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace RteExtractor.Consumption
{
    public class WeeklyForecastPeakExport
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public DateTime UpdatedDate { get; set; }

        public DateTime PeakHour { get; set; }

        public int PeakValue { get; set; }

        public float PeakTemperature { get; set; }

        public float PeakTemperatureDeviation { get; set; }
    }
}
