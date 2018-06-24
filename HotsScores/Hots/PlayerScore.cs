using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HotsScores.Hots
{
    public class PlayerScore
    {
        [JsonProperty("hero_damage")]
        public int HeroDamage { get; set; }

        [JsonProperty("siege_damage")]
        public int SiegeDamage { get; set; }

        [JsonProperty("structure_damage")]
        public int StructureDamage { get; set; }

        [JsonProperty("healing"), ]
        public int? Healing { get; set; }

        [JsonProperty("self_healing")]
        public int? SelfHealing { get; set; }

        [JsonProperty("damage_taken")]
        public int? DamageTaken { get; set; }

        [JsonProperty("takedowns")]
        public int Takedowns { get; set; }

        [JsonProperty("time_cc_enemy_heroes")]
        public int CrowdControlTime { get; set; }

        public int GetPropertyByName(string propertyName)
        { 
            object propertyValue = this.GetType().GetProperty(propertyName).GetValue(this, null);
            if(propertyValue != null)
            {
                return (int)propertyValue;
            }
            return 0;
        }
    }
}
