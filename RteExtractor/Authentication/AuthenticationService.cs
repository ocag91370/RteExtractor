using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace RteExtractor.Authentication
{
    public class AuthenticationService
    {
        private static readonly string _url = "https://digital.iservices.rte-france.com/token/oauth/";
        private static readonly string _secret = "OTljMTc0MzQtNzI0Yy00ZmFkLWFkNjAtYjU0YjQ5M2I4ZmUzOjZjYzc2NzkwLTE1MWMtNDU0OS1iN2QyLThkMTVlYjJjY2Y1MA==";

        public static async Task<ApiResult<Token>> GetToken()
        {
            // HTTP client
            using var client = new HttpClient();

            // Setting authentication mode
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", _secret);

            // Setting content type
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));

            // HTTP call
            var response = await client.PostAsync(_url, null);

            // Get result
            return await response.GetValueAsync<Token>();
        }
    }
}
