using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace RteExtractor.Extensions
{
    public static class HttpClientExtensions
    {
        public static HttpClient SetHeader(this HttpClient _this, string token)
        {
            // Setting Authorization.  
            _this.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            // Setting content type.  
            _this.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return _this;
        }
    }
}
