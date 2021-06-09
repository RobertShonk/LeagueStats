using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LeagueStats.Data.Entities {
    public class PerkDto {
        [Key]
        public int PerkId { get; set; }
        public StatPerksDto StatPerks { get; set; }
        public List<StyleDto> Styles { get; set; }
    }
}
