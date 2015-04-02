using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using CodeChallenge.Api.Client.HttpClient;
using CodeChallenge.Api.Client.Object;
using Newtonsoft.Json;
using NUnit.Framework;

namespace CodeChallenge.Api.Client.Tests
{
    [TestFixture]
    public class CodeChallengeHttpClientTests
    {
        [SetUp]
        public void Initialize()
        {
            

        }

        private ICodeChallengeHttpClient Sut;


        [Test]
        public async void Should_build_simple_get()
        {
            Sut = new CodeChallengeHttpClient("http://localhost", new FakeHandler
            {
                Response = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent("OK"),
                    RequestMessage = new HttpRequestMessage(new HttpMethod("GET"), new Uri("http://localhost"))
                },
                InnerHandler = new HttpClientHandler()
            });

            IHttpResponse test = await Sut.Get("");

            var result = await test.Data;

            Assert.IsTrue(test.IsSuccessStatusCode);
        }

        [Test]
        public async void Should_status_code_ok_when_get()
        {
            const string content =
                "{\"created\":\"2015-03-17T15:26:29.367\",\"iBeacons\":[{\"UUID\":\"f0018b9b-7509-4c31-a905-1a27d39c003c\",\"major\":9402,\"minor\":36201,\"busNumber\":4312},{\"UUID\":\"abc0f1a0-ff5d-42fa-b661-9a34a6e648f4\",\"major\":45398,\"minor\":64767,\"busNumber\":2426}]}";
            Sut = new CodeChallengeHttpClient("http://localhost", new FakeHandler
            {
                Response = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(content, Encoding.UTF8, "application/json"),
                    RequestMessage = new HttpRequestMessage(new HttpMethod("GET"), new Uri("http://localhost"))
                },
                InnerHandler = new HttpClientHandler()
            });
            IHttpResponse<BeaconResponse> test = await Sut.Get<BeaconResponse>("");

            var result = await test.Data;
            
            //TODO: split assert
            Assert.IsTrue(test.IsSuccessStatusCode);
            Assert.IsInstanceOf<BeaconResponse>(result);
            Assert.IsInstanceOf<DateTime>(result.Created);
            Assert.IsNotNull(result.Created);
            Assert.AreEqual(DateTime.Parse("2015-03-17T15:26:29.367"), result.Created);
            Assert.IsInstanceOf<List<Beacon>>(result.IBeacons);
            Assert.IsNotNull(result.IBeacons);
            Assert.AreEqual(2, result.IBeacons.Count);
            Assert.IsTrue(
                result.IBeacons.Exists(
                    b =>
                        b.UUID == "f0018b9b-7509-4c31-a905-1a27d39c003c" &&
                        b.Major == "9402" &&
                        b.Minor == "36201" &&
                        b.BusNumber == "4312"));
            Assert.IsTrue(
                result.IBeacons.Exists(
                    b =>
                        b.UUID == "abc0f1a0-ff5d-42fa-b661-9a34a6e648f4" && 
                        b.Major == "45398" && 
                        b.Minor == "64767" &&
                        b.BusNumber == "2426"));
        }


        [Test]
        public async void Should_status_code_badrequest_when_get()
        {
            const string content =
                "{\"created\":\"data\"}";
            Sut = new CodeChallengeHttpClient("http://localhost", new FakeHandler
            {
                Response = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(content, Encoding.UTF8, "application/json"),
                    RequestMessage = new HttpRequestMessage(new HttpMethod("GET"), new Uri("http://localhost"))
                },
                InnerHandler = new HttpClientHandler()
            });
            IHttpResponse<BeaconResponse> test = await Sut.Get<BeaconResponse>("");

            Assert.Throws<JsonReaderException>(async () =>
            {
                await test.Data;
            });
        }
    }
}
