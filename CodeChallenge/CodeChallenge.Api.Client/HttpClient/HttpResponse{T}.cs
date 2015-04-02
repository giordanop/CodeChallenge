using System.Net.Http;
using System.Threading.Tasks;

namespace CodeChallenge.Api.Client.HttpClient
{
    public class HttpResponse<T>: IHttpResponse<T>
    {
        public HttpResponse(HttpResponseMessage httpResponseMessage)
        {
            Message = httpResponseMessage;
        }

        public Task<T> Data
        {
            get
            {
                return Content.ReadAsAsync<T>();
            }
        }

        public bool IsSuccessStatusCode
        {
            get { return Message.IsSuccessStatusCode; }
        }

        public string ReasonPhrase
        {
            get { return Message.ReasonPhrase; }
        }

        public HttpContent Content
        {
            get { return Message.Content; }
        }

        private HttpResponseMessage Message { get; set; }
    }
}