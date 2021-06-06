using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeagueStats.Models;

namespace LeagueStats.Services {
    public interface IResultVMService {
        void SetUserMatchInfo(List<Match> matches, string summonerName);
        void SetUserSummonerSpellsUrls(Match match);
        void SetUserItemsUrls(Match match, Participant participant);
        int GetRankedSoloIndex(List<League> leagues);
    }
}
