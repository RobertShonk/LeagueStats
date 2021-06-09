using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LeagueStats.Data.Entities {
    public class StatPerksDto {
        [Key]
        public int StatPerksId { get; set; }
        public int Defense { get; set; }
        public int Flex { get; set; }
        public int Offense { get; set; }
    }
}
