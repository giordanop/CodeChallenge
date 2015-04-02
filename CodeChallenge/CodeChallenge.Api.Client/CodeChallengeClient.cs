using System;
using System.Collections.ObjectModel;
using CodeChallenge.Api.Client.HttpClient;
using CodeChallenge.Api.Client.Resource;

namespace CodeChallenge.Api.Client
{
    public class CodeChallengeClient : ICodeChallengeClient
    {
        private readonly ReadOnlyCollection<ICodeChallengeHttpClient> DisposableObjects;
        private readonly ICodeChallengeHttpClient HttpClientForItem;
        private BeaconResource BeaconInternal;
        public CodeChallengeHttpClient HttpClientForApi { get; set; }

        public CodeChallengeClient(CodeChallengeHttpClient httpClientForApi)
        {

            if (httpClientForApi == null)
            {
                throw new ArgumentNullException("httpClientForApi");
            }

            HttpClientForApi = httpClientForApi;
            DisposableObjects = new ReadOnlyCollection<ICodeChallengeHttpClient>(new[] {HttpClientForApi});
        }

        public void Dispose()
        {
            foreach (var @object in DisposableObjects)
            {   
                @object.Dispose();
            }
        }

        public IBeaconResource BeaconResource
        {

            get { return BeaconInternal ?? (BeaconInternal = new BeaconResource(HttpClientForApi)); }
        
        }
    }
}