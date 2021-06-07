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
        public int TeamId { get; set; }
        public bool Win { get; set; }
        public int Kills { get; set; }
        public int Deaths { get; set; }
        public int Assists { get; set; }
        public double KillParticipation { get; set; }
        public int TotalMinionsKilled { get; set; }
        public int Summoner1Id { get; set; }
        public int Summoner2Id { get; set; }
        public string Summoner1ImageUrl { get; set; }
        public string Summoner2ImageUrl { get; set; }
        public string Perk1Url { get; set; }
        public string Perk2Url { get; set; }

        public List<string> ItemUrlList = new List<string>();
        public string GameDuration { get; set; }

    }
}
