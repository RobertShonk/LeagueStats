using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeagueStats.Data.Entities {
    public class StatPerks {
        public int StatPerksId { get; set; }
        public int Defense { get; set; }
        public int Flex { get; set; }
        public int Offense { get; set; }
    }
}
