using System.Net.Http;
using System.Threading.Tasks;

namespace CodeChallenge.Api.Client.HttpClient
{
    public interface IHttpResponse<T>
    {
        Task<T> Data { get; }
        HttpContent Content { get; }
        bool IsSuccessStatusCode { get; }
        string ReasonPhrase { get; }
    }
}