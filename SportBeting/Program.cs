using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SportBeting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string json = CutJson(GetLiveFixturesJson());
            IEnumerable<LiveFixture> liveFixtures = JsonToFixtures(json);

            Console.WriteLine(FixturesToFormat(liveFixtures));

            Console.ReadKey();

            //log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
        }

        static string GetLiveFixturesJson()
        {
            string json = "";
            string todayStr = DateTime.Now.ToString("yyyy-MM-dd");

            using (var client = new HttpClient())
            {
                var endpoint = new Uri("https://api-football-v1.p.rapidapi.com/v3/fixtures?live=all");
                client.GetAsync(endpoint);
                client.DefaultRequestHeaders.Add("X-RapidAPI-Host", "api-football-v1.p.rapidapi.com");
                client.DefaultRequestHeaders.Add("X-RapidAPI-Key", "5a714a4005mshc90ae5b388aad58p15b512jsncf4294509ce5");
                var result = client.GetAsync(endpoint).Result;

                json = result.Content.ReadAsStringAsync().Result;
            }

            return json;
        }
        static string CutJson(string json)
        {
            string cuttedJson = "";

            cuttedJson = json.Substring(json.IndexOf("response") + 10);
            cuttedJson = cuttedJson.Remove(cuttedJson.Length - 1);

            return cuttedJson;
        }
        static IEnumerable<LiveFixture> JsonToFixtures(string json)
        {
            IEnumerable<LiveFixture> liveFixtures = JsonConvert.DeserializeObject<IEnumerable<LiveFixture>>(json);

            return liveFixtures;
        }
        static string FixturesToFormat(IEnumerable<LiveFixture> fixtures)
        {
            string emailBody = "";

            foreach (var fixture in fixtures)
            {
                if (IsSelectedFixture(fixture))
                {
                    emailBody += fixture.league.country + " - " + fixture.league.name + " : " + fixture.teams.home.name + " - " + fixture.teams.away.name
                        + " -> " + fixture.goals.home + ":" + fixture.goals.away + " - " + fixture.fixture.status.elapsed + "\n";
                }
            }

            return emailBody;
        }
        static bool IsSelectedFixture(LiveFixture fixture)
        {
            if (((fixture.goals.home == 0 && fixture.goals.away == 1) || (fixture.goals.home == 1 && fixture.goals.away == 0))
                && (fixture.fixture.status.elapsed > 40 && fixture.fixture.status.elapsed < 50))
            {
                return true;
            }

            return false;
        }
    }
}
