using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LeagueStats.Data.Entities;

namespace LeagueStats.Data {
    public class LeagueStatsContext : DbContext {
        public LeagueStatsContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Match> Matches { get; set; }
        public DbSet<Info> Infos { get; set; }
        public DbSet<Metadata> Metadatas { get; set; }
        public DbSet<Participant> Participants { get; set; }
        public DbSet<Perk> Perks { get; set; }
        public DbSet<Selection> Selections { get; set; }
        public DbSet<StatPerks> StatPerks { get; set; }
        public DbSet<Style> Styles { get; set; }
    }
}
