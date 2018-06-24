using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotsScores.ViewModels
{
    public class HeroStatsViewModel
    {
        private List<Hots.Player> playerGameEntries = new List<Hots.Player>();
        public IEnumerable<Hots.Player> PlayerEntries
        {
            get => this.playerGameEntries;
            set => this.playerGameEntries = value.ToList();
        }

        public HeroStatsViewModel(IEnumerable<Hots.Replay> replays, string playerBattleTag)
        {
            foreach (var replay in replays)
            {
                var entry = replay.Players?.Where(x => x.BattleTag.Contains(playerBattleTag));
                if (entry.Any())
                {
                    playerGameEntries.Add(entry.First());
                }
            }
            CalculateStats();
        }


        private void CalculateStats()
        {
            CalculateHeroWithMostWins();

            this.HeroWithMostDPS = this.GetHeroWithBestScore(nameof(Hots.PlayerScore.HeroDamage));
            this.HeroWithMostHealing = this.GetHeroWithBestScore(nameof(Hots.PlayerScore.Healing));
            this.HeroWithMostSiegeDamage = this.GetHeroWithBestScore(nameof(Hots.PlayerScore.SiegeDamage));
            this.HeroWithMostTanking = this.GetHeroWithBestScore(nameof(Hots.PlayerScore.DamageTaken));
        }

        private void CalculateHeroWithMostWins()
        {
            var heroes = playerGameEntries.Where(x => x.IsWinner).Select(x => x.HeroName);
            var mostWins = 0;
            var heroWithMostWins = "";

            foreach(var hero in heroes)
            {
                var wins = heroes.Count(x => x == hero);
                if(wins > mostWins)
                {
                    heroWithMostWins = hero;
                }
            }
            this.HeroWithMostWins = heroWithMostWins;
        }

        private string GetHeroWithBestScore(string scoreType)
        {
            Dictionary<string, int> heroScores = new Dictionary<string, int>();
            foreach (var entry in playerGameEntries)
            {
                if (entry.Score == null)
                {
                    continue;
                }

                int score = 0;
                int currentEntryScore = entry.Score.GetPropertyByName(scoreType);

                heroScores.TryGetValue(entry.HeroName, out score);
                if (score < currentEntryScore)
                {
                    heroScores[entry.HeroName] = currentEntryScore;
                }
            }

            if (heroScores.Any())
            { 
                return heroScores.OrderByDescending(x => x.Value).First().Key;
            }
            return String.Empty;
        }

        public string HeroWithMostWins { get; private set; }
        public string HeroWithMostHealing { get; private set; }
        public string HeroWithMostDPS { get; private set; }
        public string HeroWithMostSiegeDamage { get; private set; }
        public string HeroWithMostTanking { get; private set; }
    }
}
