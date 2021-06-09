using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeagueStats.Data.Entities;

namespace LeagueStats.Models {
    public class Metadata : MetadataDto {
        public List<string> Participants { get; set; }
    }
}
