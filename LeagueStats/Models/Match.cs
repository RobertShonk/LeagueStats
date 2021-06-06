using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeagueStats.Models {
    public class Match {
        public Metadata Metadata { get; set; }
        public Info Info { get; set; }

        //User Specific info
        //Set these so user's matches can be displayed with their own info before sending to client.
        public string SummonersChampionName { get; set; }
        public bool Win { get; set; }
        public int Summoner1Id { get; set; }
        public int Summoner2Id { get; set; }
        public string Summoner1ImageUrl { get; set; }
        public string Summoner2ImageUrl { get; set; }

        public List<string> ItemUrlList = new List<string>();

    }
}
