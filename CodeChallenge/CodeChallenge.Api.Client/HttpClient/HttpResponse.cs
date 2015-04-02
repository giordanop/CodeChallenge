using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace CodeChallenge.Api.Client.HttpClient
{
    public class HttpResponse : HttpResponse<string>, IHttpResponse
    {
        public HttpResponse(HttpResponseMessage httpResponseMessage)
            : base(httpResponseMessage)
        {
        }

        public new Task<string> Data
        {
            get
            {
                return Content.ReadAsStringAsync();
            }
        }
    }
}