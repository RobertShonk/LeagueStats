using System.Collections.Generic;
using LeagueStats.Data.Entities;

namespace LeagueStats.Models {
    public class Info : InfoDto {
        public List<Team> Teams { get; set; }
    }
}
