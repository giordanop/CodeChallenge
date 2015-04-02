using System;
using CodeChallenge.Api.Client.HttpClient;

namespace CodeChallenge.Api.Client
{
    public class CodeChallengeClientFactory : ICodeChallengeClientFactory
    {
        public ICodeChallengeClient Create(string apiUri)
        {
            if (apiUri == null)
            {
                throw new ArgumentNullException("apiUri");
            }

            var httpClientForApi = new CodeChallengeHttpClient(apiUri);
            return new CodeChallengeClient(httpClientForApi);
        }


    }
}