using System;
using System.Threading.Tasks;

namespace CodeChallenge.Api.Client.HttpClient
{
    public interface ICodeChallengeHttpClient :IDisposable
    {
        Task<IHttpResponse> Get(string resource);
        Task<IHttpResponse<T>> Get<T>(string resource);
    }
}