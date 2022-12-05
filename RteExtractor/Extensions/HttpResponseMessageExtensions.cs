using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;

namespace RteExtractor
{
    public static class HttpResponseMessageExtensions
    {
        public static async Task<ApiResult<T>> GetValueAsync<T>(this HttpResponseMessage _this) where T : class
        {
            return _this.IsSuccessStatusCode switch
            {
                true => new ApiResult<T>
                {
                    IsOk = true,
                    StatusCode = _this.StatusCode,
                    Data = JsonSerializer.Deserialize<T>(await _this.Content.ReadAsStringAsync())
                },
                _ => new ApiResult<T> { IsOk = false, StatusCode = _this.StatusCode, Data = default }
            };
        }
    }
}
