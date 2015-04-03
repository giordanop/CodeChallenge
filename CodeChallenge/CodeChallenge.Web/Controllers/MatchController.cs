using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Caching;
using System.Web.Http;
using CodeChallenge.Api.Client.Object;

namespace CodeChallenge.Web.Controllers
{
    public class MatchController : ApiController
    {
        public IHttpActionResult Post([FromBody] string[] value)
        {

            return Ok(new Beacon[]
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
                }
            });

        }
    }
}
