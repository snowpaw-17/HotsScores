using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotsScores.Hots
{
    public interface IHotsApiService
    {
        Task<Replay[]> RequestReplaysAsync(DateTime startDate, DateTime endDate, string playerBattleTag);
        Task<Talent[]> RequestTalentsAsync();
        Task<Hero[]> RequestHeroesAsync();
    }
}
