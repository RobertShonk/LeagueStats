using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LeagueStats.Data.Entities {
    public class Perk {
        [Key]
        public int PerkId { get; set; }
        public StatPerks StatPerks { get; set; }
        public List<Style> Styles { get; set; }
    }
}
