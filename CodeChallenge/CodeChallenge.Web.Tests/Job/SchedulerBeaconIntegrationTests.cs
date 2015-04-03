using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Hosting;
using CodeChallenge.Api.Client.Object;
using CodeChallenge.Web.Job;
using FluentScheduler;
using NUnit.Framework;

namespace CodeChallenge.Web.Tests.Job
{
    [TestFixture]
    public class SchedulerBeaconIntegrationTests
    {
        [SetUp]
        public void Initialize()
        {
            
        }

        [Test][Ignore]
        public void Should_execute_task_and_change_values_in_cache()
        {
            var beaconNameCache = ConfigurationManager.AppSettings["BeaconNameCache"];
            var memory = MemoryCache.Default;
            TaskManager.Initialize(new SchedulerBeacon(1));


            var beaconFeed1 = (BeaconResponse)MemoryCache.Default.Get(beaconNameCache);
            var data1 = beaconFeed1.LastUpdate;
            
            Thread.Sleep(3000);

            var beaconFeed2 = (BeaconResponse)MemoryCache.Default.Get(beaconNameCache);
            var data2 = beaconFeed2.LastUpdate;
            
            Assert.NotNull(data1);
            Assert.NotNull(data2);
            Assert.AreNotEqual(data1,data2);

        } 
    }
}
