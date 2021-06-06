using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace LeagueStats.Models {
    public class Style {
        public string Description { get; set; }
        public List<Selection> Selections { get; set; }

        [JsonProperty(PropertyName = "style")]
        public int StyleNumber { get; set; }
    }
}
