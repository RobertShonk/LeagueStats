using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeagueStats.Data;
using LeagueStats.Data.Entities;

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

        public void AddMatches(List<Match> matches)
        {
            foreach (var match in matches)
            {
                if (_ctx.Metadatas.Where(m => m.MatchId == match.Metadata.MatchId).Any())
                {
                    // if the m.MatchId == match.Metada.MatchId then the match is already in db.
                    // if so then do nothing.
                }
                else
                {
                    _ctx.Matches.Add(match);
                    _ctx.SaveChanges();
                }
            }
        }
    }
}
