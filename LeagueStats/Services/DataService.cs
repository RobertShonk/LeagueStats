using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeagueStats.Data;

namespace LeagueStats.Services {
    public class DataService : IDataService {

        private readonly LeagueStatsContext _ctx;

        public DataService(LeagueStatsContext ctx)
        {
            this._ctx = ctx;
        }
        public bool SummonerExists(string summonerName)
        {
            var exists = _ctx.Participants.Where(p => p.SummonerName == summonerName).Any();

            return exists;
        }
    }
}
