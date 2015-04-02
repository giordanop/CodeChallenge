using System.Threading.Tasks;
using CodeChallenge.Api.Client.HttpClient;
using CodeChallenge.Api.Client.Object;

namespace CodeChallenge.Api.Client.Resource
{
    public class BeaconResource : Resource,IBeaconResource
    {
        public const string ResourceForGetBeaconFeed = "BeaconsFeed";
        public BeaconResource(ICodeChallengeHttpClient httpClient) : base(httpClient)
        {
        }

        public Task<IHttpResponse<BeaconResponse>> GetBeaconsFeed()
        {
            return HttpClient.Get<BeaconResponse>(ResourceForGetBeaconFeed);
        }
    }
}