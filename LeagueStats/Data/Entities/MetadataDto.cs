using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LeagueStats.Data.Entities {
    public class MetadataDto {
        [Key]
        public int MetadataId { get; set; }
        public int DataVersion { get; set; }
        public string MatchId { get; set; }
    }
}
