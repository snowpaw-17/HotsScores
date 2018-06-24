using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace HotsScores.ViewModels
{
    public class ScoresViewModel
    {
        private Hots.Replay[] replays;
        public ScoresViewModel(IEnumerable<Hots.Replay> replays, string player)
        {
            this.HeroStats = new HeroStatsViewModel(replays, player);

            this.replays = replays.ToArray();

            this.GamesPlayed = replays.Count();
            this.GamesWon = this.HeroStats.PlayerEntries.Where(x => x.IsWinner).Count();
        }

        public HeroStatsViewModel HeroStats { get; private set; }

        public int GamesPlayed { get; private set; }
        public int GamesWon { get; private set; }
    }
}
