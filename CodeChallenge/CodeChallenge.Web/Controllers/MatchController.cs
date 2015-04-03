using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Caching;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Mvc;
using System.Web.UI;
using CodeChallenge.Api.Client.Object;

namespace CodeChallenge.Web.Controllers
{
    public class MatchController : ApiController
    {
        [System.Web.Http.HttpPost]
        [OutputCache(Duration = 0, VaryByParam = "none", Location = OutputCacheLocation.Any)]
    
        public IHttpActionResult Post([FromBody] string[] value)
        {
            string beaconNameCache = ConfigurationManager.AppSettings["BeaconNameCache"];

            BeaconResponse beaconFeedCached = (BeaconResponse) MemoryCache.Default.Get(beaconNameCache);

            return Ok(beaconFeedCached.IBeacons.FindAll(b=> value.Contains(b.UUID)).ToArray());

        }
    }
}
