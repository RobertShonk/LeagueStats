using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LeagueStats.Data.Entities {
    public class MatchDto {
        [Key]
        public int MatchId { get; set; }
        public MetadataDto Metadata { get; set; }
        public InfoDto Info { get; set; }
    }
}
