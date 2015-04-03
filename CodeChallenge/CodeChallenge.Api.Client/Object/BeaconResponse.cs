using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge.Api.Client.Object
{
    public class BeaconResponse
    {
        public DateTime Created { get; set; }
        public List<Beacon> IBeacons { get; set; }
        public DateTime? LastUpdate { get; set; }
    }
}
