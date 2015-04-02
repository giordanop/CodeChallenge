using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace CodeChallenge.Api.Client.HttpClient
{
    public class CodeChallengeHttpClient : System.Net.Http.HttpClient, ICodeChallengeHttpClient
    {
        public CodeChallengeHttpClient(string uri)
            : this(uri, new HttpClientHandler())
        {
        }

        public CodeChallengeHttpClient(string uri, HttpMessageHandler httpMessageHandler)
            : base(httpMessageHandler)
        {
            BaseAddress = new Uri(uri);
        }

        public async Task<IHttpResponse> Get(string resource)
        {        
            HttpResponseMessage message = await GetAsync(BuildUrl(resource)).ConfigureAwait(false);
            return new HttpResponse(message);
        
        }

        private string BuildUrl(string resource)
        {
            if (resource == null)
            {
                throw new ArgumentNullException("resource");
            }
            return resource;
        }
    }
}