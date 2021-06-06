using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeagueStats.Models;

namespace LeagueStats.Services {
    public interface IResultVMService {
        void SetUserMatchInfo(List<Match> matches, string summonerName);
        static void SetUserSummonerSpellsUrls(Match match);
        static void SetUserItemsUrls(Match match, Participant participant);
    }
}
