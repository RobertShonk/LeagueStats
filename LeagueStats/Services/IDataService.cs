using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeagueStats.Services {
    public interface IDataService {
        bool SummonerExists(string summonerName);
    }
}
