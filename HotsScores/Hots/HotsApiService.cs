using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flurl.Http;

namespace HotsScores.Hots
{
    public class HotsApiService : IHotsApiService
    {
        public async Task<Replay[]> RequestReplaysAsync(DateTime startDate, DateTime endDate, string playerBattleTag)
        {
            var query = CreateReplayRequestQueryFromParams(startDate, endDate, playerBattleTag);
            var replays = await RequestResourcesAsync<Replay>(query);
            return replays;
        }

        public async Task<Talent[]> RequestTalentsAsync()    
        {
            var talents = await RequestResourcesAsync<Talent>(talentsUri);
            return talents;
        }

        public async Task<Hero[]> RequestHeroesAsync()
        {
            var heroes = await RequestResourcesAsync<Hero>(heroesUri);
            return heroes;
        }

        private static async Task<T[]> RequestResourcesAsync<T>(string uri)
        {
            T[] resources = await uri
                .WithHeader("Accept", "application/json")
                .GetJsonAsync<T[]>();

            return resources;
        }

        private string CreateReplayRequestQueryFromParams(DateTime startDate, DateTime endDate, string playerBattleTag)
        {
            string datePattern = "yyyy-MM-dd";

            string query = String.Format(replaysUri, 
                startDate.ToString(datePattern), 
                endDate.ToString(datePattern), 
                Uri.EscapeDataString(playerBattleTag));
            return query;
        }

        private readonly string heroesUri = "https://api.hotslogs.com/Public/Data/Heroes";
        private readonly string talentsUri = "https://hotsapi.net/api/v1/talents";
        private readonly string replaysUri = "https://hotsapi.net/api/v1/replays?start_date={0}&end_date={1}&player={2}&with_players=true";
    }
}    
