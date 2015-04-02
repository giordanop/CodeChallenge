using System.Threading.Tasks;
using CodeChallenge.Api.Client.HttpClient;
using CodeChallenge.Api.Client.Object;

namespace CodeChallenge.Api.Client.Resource
{
    public interface IBeaconResource
    {
        Task<IHttpResponse<BeaconResponse>> GetBeaconsFeed();

    }
}