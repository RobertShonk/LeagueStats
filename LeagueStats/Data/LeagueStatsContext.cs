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

        public DbSet<MatchDto> Matches { get; set; }
        public DbSet<InfoDto> Infos { get; set; }
        public DbSet<MetadataDto> Metadatas { get; set; }
        public DbSet<ParticipantDto> Participants { get; set; }
        public DbSet<PerkDto> Perks { get; set; }
        public DbSet<SelectionDto> Selections { get; set; }
        public DbSet<StatPerksDto> StatPerks { get; set; }
        public DbSet<StyleDto> Styles { get; set; }
    }
}
