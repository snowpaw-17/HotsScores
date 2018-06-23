using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HotsScores.Hots
{
    public class Player
    {
        [JsonProperty("battletag")]
        public string BattleTag { get; set; }

        [JsonProperty("hero")]
        public string HeroName { get; set; }

        [JsonProperty("hero_level")]
        public int HeroLevel { get; set; }

        [JsonProperty("winner")]
        public bool IsWinner { get; set; }

        [JsonProperty("talents")]  
        public Dictionary<int, string> TalentBuild { get; set; }

        [JsonProperty("score")]
        public PlayerScore Score { get; set; }
    }
}
