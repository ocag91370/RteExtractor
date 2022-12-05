using RteExtractor.Authentication;
using RteExtractor.Consumption;
using RteExtractor.Ecowatt;
using System;

namespace RteExtractor
{
    class Program
    {

        static void Main(string[] args)
        {
            var token = AuthenticationService.GetToken().GetAwaiter().GetResult();
            if (!token.IsOk)
                return;

            var resultEcowatt = EcowattService.GetEcowattData(token.Data.Value).GetAwaiter().GetResult();
            if (resultEcowatt.IsOk)
                EcowattService.SaveEcowattData(resultEcowatt.Data);

            var now = DateTime.Now;
            var resultWeeklyForecast = ConsumptionService.GetWeeklyForecast(token.Data.Value, now.AddDays(-7), now).GetAwaiter().GetResult();
            if (resultWeeklyForecast.IsOk)
            {
                ConsumptionService.SaveWeeklyForecast(resultWeeklyForecast.Data);
                //ConsumptionService.SaveWeeklyForecastPeak(resultWeeklyForecast.Data);
            }

            var resultAnnualForecast = ConsumptionService.GetAnnualForecast(token.Data.Value, now.Year, now.Year + 1).GetAwaiter().GetResult();
            if (resultAnnualForecast.IsOk)
                ConsumptionService.SaveAnnualForecast(resultAnnualForecast.Data);
        }
    }
}
