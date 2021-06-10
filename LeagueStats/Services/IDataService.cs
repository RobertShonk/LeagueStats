using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeagueStats.Data.Entities;
using LeagueStats.Models;

namespace LeagueStats.Services {
    public interface IDataService {
        bool SummonerExists(string summonerName);
        void AddMatches(List<Match> matchDtos);
        List<MatchDto> GetMatchesBySummonerName(string summonerName);
    }
}
