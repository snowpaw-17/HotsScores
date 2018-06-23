using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HotsScores.Hots
{
    public class Hero
    {
        [JsonProperty("PrimaryName")]
        public string Name { get; set; }

        [JsonProperty("Group")]
        public string Role { get; set; }

        [JsonProperty("SubGroup")]
        public string Subrole { get; set; }

        [JsonProperty("ImageUrl")]
        public string Icon { get; set; }
    }
}
