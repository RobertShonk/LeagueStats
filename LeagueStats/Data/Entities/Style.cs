using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeagueStats.Data.Entities {
    public class Style {
        public int StyleId { get; set; }
        public string Description { get; set; }
        public List<Selection> Selections { get; set; }
        public int StyleNumber { get; set; }
    }
}
