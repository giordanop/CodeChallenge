using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;
using System.Threading.Tasks;
using CodeChallenge.Api.Client.Object;
using Microsoft.Owin.Testing;
using NUnit.Framework;

namespace CodeChallenge.Web.Tests.Controllers.IntegrationTests
{
    [TestFixture]
    public class MatchControllerIntegrationTests
    {
        [Test]
        public async void Should_post_beacon_feed_and_return_beacon_active()
        {
            using (var server = TestServer.Create<Startup>())
            {
                using (var client = new HttpClient(server.Handler))
                {
                    HttpContent content = new ObjectContent(typeof(string[]), new[]
                    {
                        "f0018b9b-7509-4c31-a905-1a27d39c003c",
                        "abc0f1a0-ff5d-42fa-b661-9a34a6e648f4",
                        "00000000-0000-0000-0000-000000000000"
                    }, new JsonMediaTypeFormatter());
                    var response = await client.PostAsync("http://localhost:1745/api/match/", content); //TODO: remove http://localhost:1745

                    var result = await response.Content.ReadAsAsync<Beacon[]>();
                    Assert.IsNotNull(result);
                }
            }
        }
    }
}
