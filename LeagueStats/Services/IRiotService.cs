using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeagueStats.Models;

namespace LeagueStats.Services {
    public interface IRiotService {
        Task<Summoner> GetSummonerAsync(string summonerName);
        Task<List<League>> GetLeagueAsync(string id);
        Task<List<string>> GetMatchIdsAsync(string puuid);
        Task<List<Match>> GetMatchesAsync(List<string> matchIds);
    }
}
