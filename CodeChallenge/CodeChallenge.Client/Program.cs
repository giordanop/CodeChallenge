using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CodeChallenge.Api.Client.Object;

namespace CodeChallenge.Client
{
    public class Program
    {
        public static readonly HttpClient client = new HttpClient();
        public static List<string> beaconUUIDs = new List<string>()
        {
            "f0018b9b-7509-4c31-a905-1a27d39c003c",
            "abc0f1a0-ff5d-42fa-b661-9a34a6e648f4",
            "1554a9d8-63ef-448c-bc0b-87560d971481",
            "831d1540-b18b-48a1-b45e-5ae715392ea9",
            "6140ec7a-86c4-4a06-ad59-d0829575c5e9",
            "359ea48e-eaa3-4da8-aa2f-5cf290bb4885",
            "8f08834e-b5cd-4d77-990c-23204673f31d",

            "00000000-0000-0000-0000-000000000000",
            "11111111-1111-1111-1111-111111111111",
            "22222222-2222-2222-2222-222222222222",
            "33333333-3333-3333-3333-333333333333"

        };



        private static void Main(string[] args)
        {

            client.BaseAddress = new Uri("http://localhost:1745/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            Console.WriteLine("Press enter to start");
            
            Console.Read();

            while (true)
            {
                Console.WriteLine();

                FindMatches();

                Console.WriteLine();
                Console.WriteLine("Press enter to continue");
                Console.Read();
                Console.Read();

            }
        }

        private static void FindMatches()
        {
            var beaconToSend = beaconUUIDs.Shuffle().Take(new Random().Next(0, 10)).ToArray();
            Console.WriteLine();
            Console.WriteLine("Beacon(s) sent:");
            if (beaconToSend.Length == 0)
            {
                Console.WriteLine("None");
            }
            foreach (var c in beaconToSend)
            {
                Console.WriteLine("UUID: {0}", c);
            }

            HttpContent content = new ObjectContent(typeof (string[]), beaconToSend, new JsonMediaTypeFormatter());

            //List all Customers
            HttpResponseMessage response = client.PostAsync("api/match", content).Result;

            Console.WriteLine();
            Console.WriteLine("Beacon matched:");
            if (response.IsSuccessStatusCode)
            {
                var beacon = response.Content.ReadAsAsync<Beacon[]>().Result;
                if (beacon.Length == 0)
                {
                    Console.WriteLine("None");
                }
                foreach (var c in beacon)
                {
                    Console.WriteLine("UUID: {0}\tminor: {1}\tmajor: {2}\tbus number: {3}", c.UUID, c.Minor,
                        c.Major, c.BusNumber);
                }
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int) response.StatusCode, response.ReasonPhrase);
            }
        }
    }
}
