using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeagueStats.Data.Entities {
    public class Selection {
        [Key]
        public int SelectionId { get; set; }
        [ForeignKey("StyleId")]
        public int StyleId { get; set; }
        public int Perk { get; set; }
        public int Var1 { get; set; }
        public int Var2 { get; set; }
        public int Var3 { get; set; }
    }
}
