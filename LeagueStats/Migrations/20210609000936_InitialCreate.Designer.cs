// <auto-generated />
using System;
using LeagueStats.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LeagueStats.Migrations
{
    [DbContext(typeof(LeagueStatsContext))]
    [Migration("20210609000936_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LeagueStats.Data.Entities.Info", b =>
                {
                    b.Property<int>("InfoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("GameCreation")
                        .HasColumnType("bigint");

                    b.Property<long>("GameDuration")
                        .HasColumnType("bigint");

                    b.Property<long>("GameId")
                        .HasColumnType("bigint");

                    b.Property<string>("GameMode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GameName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("GameStartTimestamp")
                        .HasColumnType("bigint");

                    b.Property<string>("GameType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GameVersion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MapId")
                        .HasColumnType("int");

                    b.Property<string>("PlatformId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("QueueId")
                        .HasColumnType("int");

                    b.HasKey("InfoId");

                    b.ToTable("Infos");
                });

            modelBuilder.Entity("LeagueStats.Data.Entities.Match", b =>
                {
                    b.Property<int>("MatchId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("InfoId")
                        .HasColumnType("int");

                    b.Property<int?>("MetadataId")
                        .HasColumnType("int");

                    b.HasKey("MatchId");

                    b.HasIndex("InfoId");

                    b.HasIndex("MetadataId");

                    b.ToTable("Matches");
                });

            modelBuilder.Entity("LeagueStats.Data.Entities.Metadata", b =>
                {
                    b.Property<int>("MetadataId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DataVersion")
                        .HasColumnType("int");

                    b.Property<string>("MatchId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MetadataId");

                    b.ToTable("Metadatas");
                });

            modelBuilder.Entity("LeagueStats.Data.Entities.Participant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Assists")
                        .HasColumnType("int");

                    b.Property<int>("BaronKills")
                        .HasColumnType("int");

                    b.Property<int>("BountyLevel")
                        .HasColumnType("int");

                    b.Property<long>("ChampExperience")
                        .HasColumnType("bigint");

                    b.Property<int>("ChampionId")
                        .HasColumnType("int");

                    b.Property<string>("ChampionName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ConsumablesPurchased")
                        .HasColumnType("int");

                    b.Property<long>("DamageDealtToBuildings")
                        .HasColumnType("bigint");

                    b.Property<long>("DamageDealtToObjectives")
                        .HasColumnType("bigint");

                    b.Property<long>("DamageDealtToTurrets")
                        .HasColumnType("bigint");

                    b.Property<long>("DamageSelfMitigated")
                        .HasColumnType("bigint");

                    b.Property<int>("Deaths")
                        .HasColumnType("int");

                    b.Property<int>("DetectorWardsPlaced")
                        .HasColumnType("int");

                    b.Property<int>("DoubleKills")
                        .HasColumnType("int");

                    b.Property<int>("DragonKills")
                        .HasColumnType("int");

                    b.Property<bool>("FirstBloodAssist")
                        .HasColumnType("bit");

                    b.Property<bool>("FirstBloodKill")
                        .HasColumnType("bit");

                    b.Property<bool>("FirstTowerAssist")
                        .HasColumnType("bit");

                    b.Property<bool>("FirstTowerKill")
                        .HasColumnType("bit");

                    b.Property<bool>("GameEndedInEarlySurrender")
                        .HasColumnType("bit");

                    b.Property<bool>("GameEndedInSurrender")
                        .HasColumnType("bit");

                    b.Property<long>("GoldEarned")
                        .HasColumnType("bigint");

                    b.Property<long>("GoldSpent")
                        .HasColumnType("bigint");

                    b.Property<string>("IndividualPosition")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("InfoId")
                        .HasColumnType("int");

                    b.Property<int>("InhibitorKills")
                        .HasColumnType("int");

                    b.Property<int>("InhibitorsLost")
                        .HasColumnType("int");

                    b.Property<int>("Item0")
                        .HasColumnType("int");

                    b.Property<int>("Item1")
                        .HasColumnType("int");

                    b.Property<int>("Item2")
                        .HasColumnType("int");

                    b.Property<int>("Item3")
                        .HasColumnType("int");

                    b.Property<int>("Item4")
                        .HasColumnType("int");

                    b.Property<int>("Item5")
                        .HasColumnType("int");

                    b.Property<int>("Item6")
                        .HasColumnType("int");

                    b.Property<int>("ItemsPurchased")
                        .HasColumnType("int");

                    b.Property<int>("KillingSprees")
                        .HasColumnType("int");

                    b.Property<int>("Kills")
                        .HasColumnType("int");

                    b.Property<string>("Lane")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LargestCriticalStrike")
                        .HasColumnType("int");

                    b.Property<int>("LargestKillingSpree")
                        .HasColumnType("int");

                    b.Property<int>("LargestMultiKill")
                        .HasColumnType("int");

                    b.Property<int>("LongestTimeSpentLeveling")
                        .HasColumnType("int");

                    b.Property<long>("MagicDamageDealt")
                        .HasColumnType("bigint");

                    b.Property<long>("MagicDamageDealtToChampions")
                        .HasColumnType("bigint");

                    b.Property<long>("MagicDamageTaken")
                        .HasColumnType("bigint");

                    b.Property<int>("NeutralMinionsKilled")
                        .HasColumnType("int");

                    b.Property<int>("NexusKills")
                        .HasColumnType("int");

                    b.Property<int>("NexusLost")
                        .HasColumnType("int");

                    b.Property<int>("ObjectivesStolen")
                        .HasColumnType("int");

                    b.Property<int>("ObjectivesStolenAssists")
                        .HasColumnType("int");

                    b.Property<int>("ParticipantId")
                        .HasColumnType("int");

                    b.Property<int>("PentaKills")
                        .HasColumnType("int");

                    b.Property<int?>("PerksPerkId")
                        .HasColumnType("int");

                    b.Property<long>("PhysicalDamageDealt")
                        .HasColumnType("bigint");

                    b.Property<long>("PhysicalDamageDealtToChampions")
                        .HasColumnType("bigint");

                    b.Property<long>("PhysicalDamageTaken")
                        .HasColumnType("bigint");

                    b.Property<int>("ProfileIcon")
                        .HasColumnType("int");

                    b.Property<string>("Puuid")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("QuadraKills")
                        .HasColumnType("int");

                    b.Property<string>("RiotIdName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RiotIdTagLine")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SightWardsBoughtInGame")
                        .HasColumnType("int");

                    b.Property<int>("Spell1Casts")
                        .HasColumnType("int");

                    b.Property<int>("Spell2Casts")
                        .HasColumnType("int");

                    b.Property<int>("Spell3Casts")
                        .HasColumnType("int");

                    b.Property<int>("Spell4Casts")
                        .HasColumnType("int");

                    b.Property<int>("Summoner1Casts")
                        .HasColumnType("int");

                    b.Property<int>("Summoner1Id")
                        .HasColumnType("int");

                    b.Property<int>("Summoner2Casts")
                        .HasColumnType("int");

                    b.Property<int>("Summoner2Id")
                        .HasColumnType("int");

                    b.Property<string>("SummonerId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SummonerLevel")
                        .HasColumnType("int");

                    b.Property<string>("SummonerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TeamEarlySurrendered")
                        .HasColumnType("bit");

                    b.Property<int>("TeamId")
                        .HasColumnType("int");

                    b.Property<string>("TeamPosition")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("TimeCCingOthers")
                        .HasColumnType("bigint");

                    b.Property<long>("TimePlayed")
                        .HasColumnType("bigint");

                    b.Property<long>("TotalDamageDealt")
                        .HasColumnType("bigint");

                    b.Property<long>("TotalDamageDealtToChampions")
                        .HasColumnType("bigint");

                    b.Property<long>("TotalDamageShieldedOnTeammates")
                        .HasColumnType("bigint");

                    b.Property<long>("TotalDamageTaken")
                        .HasColumnType("bigint");

                    b.Property<long>("TotalHeal")
                        .HasColumnType("bigint");

                    b.Property<long>("TotalHealsOnTeammates")
                        .HasColumnType("bigint");

                    b.Property<int>("TotalMinionsKilled")
                        .HasColumnType("int");

                    b.Property<int>("TotalTimeCCDealt")
                        .HasColumnType("int");

                    b.Property<long>("TotalTimeSpentDead")
                        .HasColumnType("bigint");

                    b.Property<int>("TotalUnitsHealed")
                        .HasColumnType("int");

                    b.Property<int>("TripleKills")
                        .HasColumnType("int");

                    b.Property<long>("TrueDamageDealt")
                        .HasColumnType("bigint");

                    b.Property<long>("TrueDamageDealtToChampions")
                        .HasColumnType("bigint");

                    b.Property<long>("TrueDamageTaken")
                        .HasColumnType("bigint");

                    b.Property<int>("TurretKills")
                        .HasColumnType("int");

                    b.Property<int>("TurretsLost")
                        .HasColumnType("int");

                    b.Property<int>("UnrealKills")
                        .HasColumnType("int");

                    b.Property<int>("VisionScore")
                        .HasColumnType("int");

                    b.Property<int>("VisionWardsBoughtInGame")
                        .HasColumnType("int");

                    b.Property<int>("WardsKilled")
                        .HasColumnType("int");

                    b.Property<int>("WardsPlaced")
                        .HasColumnType("int");

                    b.Property<bool>("Win")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("InfoId");

                    b.HasIndex("PerksPerkId");

                    b.ToTable("Participants");
                });

            modelBuilder.Entity("LeagueStats.Data.Entities.Perk", b =>
                {
                    b.Property<int>("PerkId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("StatPerksId")
                        .HasColumnType("int");

                    b.HasKey("PerkId");

                    b.HasIndex("StatPerksId");

                    b.ToTable("Perks");
                });

            modelBuilder.Entity("LeagueStats.Data.Entities.Selection", b =>
                {
                    b.Property<int>("SelectionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Perk")
                        .HasColumnType("int");

                    b.Property<int?>("StyleId")
                        .HasColumnType("int");

                    b.Property<int>("Var1")
                        .HasColumnType("int");

                    b.Property<int>("Var2")
                        .HasColumnType("int");

                    b.Property<int>("Var3")
                        .HasColumnType("int");

                    b.HasKey("SelectionId");

                    b.HasIndex("StyleId");

                    b.ToTable("Selections");
                });

            modelBuilder.Entity("LeagueStats.Data.Entities.StatPerks", b =>
                {
                    b.Property<int>("StatPerksId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Defense")
                        .HasColumnType("int");

                    b.Property<int>("Flex")
                        .HasColumnType("int");

                    b.Property<int>("Offense")
                        .HasColumnType("int");

                    b.HasKey("StatPerksId");

                    b.ToTable("StatPerks");
                });

            modelBuilder.Entity("LeagueStats.Data.Entities.Style", b =>
                {
                    b.Property<int>("StyleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PerkId")
                        .HasColumnType("int");

                    b.Property<int>("StyleNumber")
                        .HasColumnType("int");

                    b.HasKey("StyleId");

                    b.HasIndex("PerkId");

                    b.ToTable("Styles");
                });

            modelBuilder.Entity("LeagueStats.Data.Entities.Match", b =>
                {
                    b.HasOne("LeagueStats.Data.Entities.Info", "Info")
                        .WithMany()
                        .HasForeignKey("InfoId");

                    b.HasOne("LeagueStats.Data.Entities.Metadata", "Metadata")
                        .WithMany()
                        .HasForeignKey("MetadataId");

                    b.Navigation("Info");

                    b.Navigation("Metadata");
                });

            modelBuilder.Entity("LeagueStats.Data.Entities.Participant", b =>
                {
                    b.HasOne("LeagueStats.Data.Entities.Info", null)
                        .WithMany("Participants")
                        .HasForeignKey("InfoId");

                    b.HasOne("LeagueStats.Data.Entities.Perk", "Perks")
                        .WithMany()
                        .HasForeignKey("PerksPerkId");

                    b.Navigation("Perks");
                });

            modelBuilder.Entity("LeagueStats.Data.Entities.Perk", b =>
                {
                    b.HasOne("LeagueStats.Data.Entities.StatPerks", "StatPerks")
                        .WithMany()
                        .HasForeignKey("StatPerksId");

                    b.Navigation("StatPerks");
                });

            modelBuilder.Entity("LeagueStats.Data.Entities.Selection", b =>
                {
                    b.HasOne("LeagueStats.Data.Entities.Style", null)
                        .WithMany("Selections")
                        .HasForeignKey("StyleId");
                });

            modelBuilder.Entity("LeagueStats.Data.Entities.Style", b =>
                {
                    b.HasOne("LeagueStats.Data.Entities.Perk", null)
                        .WithMany("Styles")
                        .HasForeignKey("PerkId");
                });

            modelBuilder.Entity("LeagueStats.Data.Entities.Info", b =>
                {
                    b.Navigation("Participants");
                });

            modelBuilder.Entity("LeagueStats.Data.Entities.Perk", b =>
                {
                    b.Navigation("Styles");
                });

            modelBuilder.Entity("LeagueStats.Data.Entities.Style", b =>
                {
                    b.Navigation("Selections");
                });
#pragma warning restore 612, 618
        }
    }
}
