using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeagueStats.Models {
    public class Team {
        public List<Ban> Bans { get; set; }
        public Objectives Objectives { get; set; }
        public int TeamId { get; set; }
        public bool Win { get; set; }

    }
}
