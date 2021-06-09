using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace LeagueStats.Data.Entities {
    public class Style {
        [Key]
        public int StyleId { get; set; }
        public string Description { get; set; }
        public List<Selection> Selections { get; set; }

        [JsonProperty(PropertyName = "style")]
        public int StyleNumber { get; set; }
    }
}
