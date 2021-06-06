using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


//Match.Info.List<Participant>.List<Perk>.
namespace LeagueStats.Models {
    public class Perk {
        public StatPerks StatPerks { get; set; }
        public List<Style> Styles { get; set; }

    }
}
