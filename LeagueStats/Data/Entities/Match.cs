using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LeagueStats.Data.Entities {
    public class Match {
        [Key]
        public int MatchId { get; set; }
        public Metadata Metadata { get; set; }
        public Info Info { get; set; }
    }
}
