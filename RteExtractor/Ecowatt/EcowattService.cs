using RteExtractor.Extensions;
using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace RteExtractor.Ecowatt
{
    public class EcowattService
    {
        private static readonly string _url = "https://digital.iservices.rte-france.com/open_api/ecowatt/v4/signals";

        public static async Task<ApiResult<EcowattData>>GetEcowattData(string token)
        {
            using var client = new HttpClient().SetHeader(token);
            var response = await client.GetAsync(_url);

            return await response.GetValueAsync<EcowattData>();
        }

        public static void SaveEcowattData(EcowattData data)
        {
            if (data == null)
                return;

            var fileName = $"ExportEcowatt_{DateTime.Now:yyyyddMM-HHmmss}";

            File.WriteAllText($"{fileName}.json", JsonSerializer.Serialize(data));

            var flattenData = data.Signals.SelectMany(d => d.Values.Select(h => new AllSignals
            {
                Day = d.Day,
                DayValue = d.Value,
                Message = d.Message,
                Hour = h.Hour,
                HourValue = h.Value
            }));

            flattenData.ExportToTextFile($"{fileName}.csv");
        }
    }
}
