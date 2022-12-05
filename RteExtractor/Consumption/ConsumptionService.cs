using RteExtractor.Extensions;
using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace RteExtractor.Consumption
{
    public class ConsumptionService
    {
        private static readonly string _urlWeeklyForecasts = "https://digital.iservices.rte-france.com/open_api/consumption/v1/weekly_forecasts";
        private static readonly string _urlAnnualForecasts = "https://digital.iservices.rte-france.com/open_api/consumption/v1/annual_forecasts";

        public static async Task<ApiResult<WeeklyForecastResponse>> GetWeeklyForecast(string token, DateTime startDate, DateTime endDate)
        {
            var url = new UriBuilder(_urlWeeklyForecasts)
            {
                Query = $"start_date={startDate:yyyy-MM-ddThh:mm:sszzzzzz}&end_date={endDate:yyyy-MM-ddThh:mm:sszzzzzz}"
            }.ToString();

            using var client = new HttpClient().SetHeader(token);
            var response = await client.GetAsync(url);

            return await response.GetValueAsync<WeeklyForecastResponse>();
        }

        public static async Task<ApiResult<AnnualForecastResponse>> GetAnnualForecast(string token, DateTime startDate, DateTime endDate)
        {
            var query = $"start_date={startDate:yyyy-MM-ddTHH:mm:sszzzzzz}&end_date={endDate:yyyy-MM-ddTHH:mm:sszzzzzz}";
            var url = new UriBuilder(_urlAnnualForecasts)
            {
                Query = query
            }.ToString();

            using var client = new HttpClient().SetHeader(token);
            var response = await client.GetAsync(url);

            return await response.GetValueAsync<AnnualForecastResponse>();
        }

        public static async Task<ApiResult<AnnualForecastResponse>> GetAnnualForecast(string token, int startYear, int endYear)
        {
            var startDate = new DateTime(startYear, 1, 1, 0, 0, 0);
            var endDate = new DateTime(endYear, 1, 1, 0, 0, 0);

            return await GetAnnualForecast(token, startDate, endDate);
        }

        public static async Task<ApiResult<AnnualForecastResponse>> GetAnnualForecast(string token)
        {
            using var client = new HttpClient().SetHeader(token);
            var response = await client.GetAsync(_urlAnnualForecasts);

            return await response.GetValueAsync<AnnualForecastResponse>();
        }

        public static void SaveWeeklyForecast(WeeklyForecastResponse data)
        {
            if (data == null)
                return;

            var fileName = $"ExportWeeklyForecast_{DateTime.Now:yyyyddMM-HHmmss}";

            File.WriteAllText($"{fileName}.json", JsonSerializer.Serialize(data));

            var flattenData = data.Forecasts.SelectMany(x => x.Values.Select(y => new WeeklyForecastExport
            {
                StartDate = x.StartDate,
                EndDate = x.EndDate,
                UpdatedDate = x.UpdatedDate,
                PeakHour = x.Peak.Hour,
                PeakValue = x.Peak.Value,
                PeakTemperature = x.Peak.Temperature,
                PeakTemperatureDeviation = x.Peak.TemperatureDeviation,
                IntervalStartDate = y.StartDate,
                IntervalEndDate = y.EndDate,
                IntervalValue = y.Value,
            }));

            flattenData.ExportToTextFile($"{fileName}.csv");
        }

        public static void SaveWeeklyForecastPeak(WeeklyForecastResponse data)
        {
            if (data == null)
                return;

            var fileName = $"ExportWeeklyForecastPeak_{DateTime.Now:yyyyddMM-HHmmss}";

            File.WriteAllText($"{fileName}.json", JsonSerializer.Serialize(data));

            var flattenData = data.Forecasts.Select(x => new WeeklyForecastPeakExport
            {
                StartDate = x.StartDate,
                EndDate = x.EndDate,
                UpdatedDate = x.UpdatedDate,
                PeakHour = x.Peak.Hour,
                PeakValue = x.Peak.Value,
                PeakTemperature = x.Peak.Temperature,
                PeakTemperatureDeviation = x.Peak.TemperatureDeviation,
            });

            flattenData.ExportToTextFile($"{fileName}.csv");
        }

        public static void SaveAnnualForecast(AnnualForecastResponse data)
        {
            if (data == null)
                return;

            var fileName = $"ExportAnnualForecast_{DateTime.Now:yyyyddMM-HHmmss}";

            File.WriteAllText($"{fileName}.json", JsonSerializer.Serialize(data));

            //var flattenData = data.Forecasts.SelectMany(x => x.Values.Select(y => new WeeklyForecastExport
            //{
            //    StartDate = x.StartDate,
            //    EndDate = x.EndDate,
            //    UpdatedDate = x.UpdatedDate,
            //    PeakHour = x.Peak.Hour,
            //    PeakValue = x.Peak.Value,
            //    PeakTemperature = x.Peak.Temperature,
            //    PeakTemperatureDeviation = x.Peak.TemperatureDeviation,
            //    IntervalStartDate = y.StartDate,
            //    IntervalEndDate = y.EndDate,
            //    IntervalValue = y.Value,
            //}));

            //flattenData.ExportToTextFile($"ExportWeeklyForecast_{DateTime.Now:yyyyddMM-HHmmss}.csv");
        }
    }
}
