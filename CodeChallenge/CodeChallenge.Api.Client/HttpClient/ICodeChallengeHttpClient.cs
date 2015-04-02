using System.Threading.Tasks;

namespace CodeChallenge.Api.Client.HttpClient
{
    public interface ICodeChallengeHttpClient
    {
        Task<IHttpResponse> Get(string resource);
    }
}