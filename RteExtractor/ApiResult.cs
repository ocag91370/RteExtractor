using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RteExtractor
{
    public class ApiResult<T> where T : class
    {
        public bool IsOk { get; set; }

        public HttpStatusCode StatusCode { get; set; }

        public T Data { get; set; }
    }
}
