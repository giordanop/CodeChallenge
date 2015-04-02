using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeChallenge.Api.Client.HttpClient;
using CodeChallenge.Api.Client.Object;
using NUnit.Framework;

namespace CodeChallenge.Api.Client.Tests
{
    [TestFixture]
    public class CodeChallengeIntegrationsTests
    {
        [SetUp]
        public void Initialize()
        {
            string apiUri = ConfigurationManager.AppSettings["Api"];

            Sut = new CodeChallengeClientFactory().Create(apiUri);
        }

        private ICodeChallengeClient Sut;


        [Test]
        public async void Should_return_status_ok_when_get_beacons_feed()
        {
            IHttpResponse<BeaconResponse> test = await Sut.BeaconResource.GetBeaconsFeed();
            Assert.IsTrue(test.IsSuccessStatusCode);
            //TODO: split tests
            BeaconResponse beaconsFeed = await test.Data;
            Assert.IsNotNull(beaconsFeed);
        }
    }
}

