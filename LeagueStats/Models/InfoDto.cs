using System.Collections.Generic;
using LeagueStats.Data.Entities;

namespace LeagueStats.Models {
    public class InfoDto : Info {
        public List<Team> Teams { get; set; }
    }
}
