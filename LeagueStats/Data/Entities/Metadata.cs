using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeagueStats.Data.Entities {
    public class Metadata {
        public int MetadataId { get; set; }
        public int DataVersion { get; set; }
        public string MatchId { get; set; }
    }
}
