using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeChallenge.Api.Client.HttpClient;

namespace CodeChallenge.Api.Client.Resource
{

    public abstract class Resource
    {
        protected readonly ICodeChallengeHttpClient HttpClient;

        protected Resource(ICodeChallengeHttpClient httpClient)
        {
            if (httpClient == null)
            {
                throw new ArgumentNullException("httpClient");
            }

            HttpClient = httpClient;
        }
    }
}
