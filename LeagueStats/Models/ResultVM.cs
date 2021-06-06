using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeagueStats.Models {
    public class ResultVM {
        public Summoner Summoner { get; set; }
        public List<League> Leagues { get; set; }
        public List<string> MatchIds { get; set; }
        public List<Match> Matches { get; set; }

        // Sets the index of Ranked Solo/Duo in Leagues list.
        public int RankedSoloDuoIndex { get; set; }
    }
}
