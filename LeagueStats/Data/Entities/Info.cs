using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LeagueStats.Data.Entities {
    public class Info {
        [Key]
        public int InfoId { get; set; }
        public long GameCreation { get; set; }
        public long GameDuration { get; set; }
        public long GameId { get; set; }
        public string GameMode { get; set; }
        public string GameName { get; set; }
        public long GameStartTimestamp { get; set; }
        public string GameType { get; set; }
        public string GameVersion { get; set; }
        public int MapId { get; set; }
        public List<Participant> Participants { get; set; }
        public string PlatformId { get; set; }
        public int QueueId { get; set; }
    }
}
