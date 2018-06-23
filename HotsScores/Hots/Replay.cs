using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HotsScores.Hots
{
    public class Replay
    {
        [JsonProperty("game_type")]
        public string GameType { get; set; }

        [JsonProperty("game_map")]
        public string Map { get; set; }

        [JsonProperty("game_length")]
        public int GameLength { get; set; }

        [JsonProperty("players")]
        public Player[] Players { get; set; }

    }
}
