using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Mvc;
using CodeChallenge.Api.Client.Object;
using CodeChallenge.Web;
using CodeChallenge.Web.Controllers;
using NUnit.Framework;

namespace CodeChallenge.Web.Tests.Controllers
{
    [TestFixture]
    public class MatchControllerTest
    {
        [Test]
        public async void Post()
        {
            // Arrange
            MatchController controller = new MatchController();

            BeaconResponse beaconResponse = new BeaconResponse()
            {
                Created = DateTime.Now,
                IBeacons = new List<Beacon>()
                {
                    new Beacon()
                    {
                        UUID = "f0018b9b-7509-4c31-a905-1a27d39c003c",
                        Major = "9402",
                        Minor = "36201",
                        BusNumber = "4312"
                    },
                    new Beacon()
                    {
                        UUID = "abc0f1a0-ff5d-42fa-b661-9a34a6e648f4",
                        Major = "45398",
                        Minor = "64767",
                        BusNumber = "2426"
                    },
                    new Beacon()
                    {
                        UUID = "g2448b9b-8909-4w41-a135-9a12d78c003c",
                        Major = "98765",
                        Minor = "4321",
                        BusNumber = "1234"
                    }
                }
            };

            MemoryCache.Default.Set("BeaconsFeed",beaconResponse,DateTimeOffset.MaxValue);

            // Act
            var  result = controller.Post(new[]
            {
                "f0018b9b-7509-4c31-a905-1a27d39c003c", 
                "abc0f1a0-ff5d-42fa-b661-9a34a6e648f4",
                "00000000-0000-0000-0000-000000000000"
            });

            // Assert
            var contentResult = result as OkNegotiatedContentResult<Beacon[]>;

            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(2,contentResult.Content.Length);

            Assert.IsInstanceOf<Beacon>(contentResult.Content.Single(
                b =>
                    b.UUID == "f0018b9b-7509-4c31-a905-1a27d39c003c" &&
                    b.Major == "9402" &&
                    b.Minor == "36201" &&
                    b.BusNumber == "4312"));
            Assert.IsInstanceOf<Beacon>(contentResult.Content.Single(
                b =>
                    b.UUID == "abc0f1a0-ff5d-42fa-b661-9a34a6e648f4" &&
                    b.Major == "45398" &&
                    b.Minor == "64767" &&
                    b.BusNumber == "2426"));
        }
    }
}


