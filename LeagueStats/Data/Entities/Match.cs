using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeagueStats.Data.Entities {
    public class Match {
        public int MatchId { get; set; }
        public Metadata Metadata { get; set; }
        public Info Info { get; set; }
    }
}
