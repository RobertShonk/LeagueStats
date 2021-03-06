using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace LeagueStats.Data.Entities {
    public class Participant {
        [Key]
        public int Id { get; set; }
        [ForeignKey("InfoId")]
        public int InfoId { get; set; }
        public int Assists { get; set; }
        public int BaronKills { get; set; }
        public int BountyLevel { get; set; }
        public long ChampExperience { get; set; }
        public int ChampionId { get; set; }
        public string ChampionName { get; set; }
        public int ConsumablesPurchased { get; set; }
        public long DamageDealtToBuildings { get; set; }
        public long DamageDealtToObjectives { get; set; }
        public long DamageDealtToTurrets { get; set; }
        public long DamageSelfMitigated { get; set; }
        public int Deaths { get; set; }
        public int DetectorWardsPlaced { get; set; }
        public int DoubleKills { get; set; }
        public int DragonKills { get; set; }
        public bool FirstBloodAssist { get; set; }
        public bool FirstBloodKill { get; set; }
        public bool FirstTowerAssist { get; set; }
        public bool FirstTowerKill { get; set; }
        public bool GameEndedInEarlySurrender { get; set; }
        public bool GameEndedInSurrender { get; set; }
        public long GoldEarned { get; set; }
        public long GoldSpent { get; set; }
        public string IndividualPosition { get; set; }
        public int InhibitorKills { get; set; }
        public int InhibitorsLost { get; set; }
        public int Item0 { get; set; }
        public int Item1 { get; set; }
        public int Item2 { get; set; }
        public int Item3 { get; set; }
        public int Item4 { get; set; }
        public int Item5 { get; set; }
        public int Item6 { get; set; }
        public int ItemsPurchased { get; set; }
        public int KillingSprees { get; set; }
        public int Kills { get; set; }
        public string Lane { get; set; }
        public int LargestCriticalStrike { get; set; }
        public int LargestKillingSpree { get; set; }
        public int LargestMultiKill { get; set; }
        public int LongestTimeSpentLeveling { get; set; }
        public long MagicDamageDealt { get; set; }
        public long MagicDamageDealtToChampions { get; set; }
        public long MagicDamageTaken { get; set; }
        public int NeutralMinionsKilled { get; set; }
        public int NexusKills { get; set; }
        public int NexusLost { get; set; }
        public int ObjectivesStolen { get; set; }
        public int ObjectivesStolenAssists { get; set; }
        public int ParticipantId { get; set; }
        public int PentaKills { get; set; }
        public Perk Perks { get; set; }
        [ForeignKey("PerksPerkId")]
        public int PerksPerkId { get; set; }
        public long PhysicalDamageDealt { get; set; }
        public long PhysicalDamageDealtToChampions { get; set; }
        public long PhysicalDamageTaken { get; set; }
        public int ProfileIcon { get; set; }
        public string Puuid { get; set; }
        public int QuadraKills { get; set; }
        public string RiotIdName { get; set; }
        public string RiotIdTagLine { get; set; }
        public string Role { get; set; }
        public int SightWardsBoughtInGame { get; set; }
        public int Spell1Casts { get; set; }
        public int Spell2Casts { get; set; }
        public int Spell3Casts { get; set; }
        public int Spell4Casts { get; set; }
        public int Summoner1Casts { get; set; }
        public int Summoner1Id { get; set; }
        public int Summoner2Casts { get; set; }
        public int Summoner2Id { get; set; }
        public string SummonerId { get; set; }
        public int SummonerLevel { get; set; }
        public string SummonerName { get; set; }
        public bool TeamEarlySurrendered { get; set; }
        public int TeamId { get; set; }
        public string TeamPosition { get; set; }
        public long TimeCCingOthers { get; set; }
        public long TimePlayed { get; set; }
        public long TotalDamageDealt { get; set; }
        public long TotalDamageDealtToChampions { get; set; }
        public long TotalDamageShieldedOnTeammates { get; set; }
        public long TotalDamageTaken { get; set; }
        public long TotalHeal { get; set; }
        public long TotalHealsOnTeammates { get; set; }
        public int TotalMinionsKilled { get; set; }
        public int TotalTimeCCDealt { get; set; }
        public long TotalTimeSpentDead { get; set; }
        public int TotalUnitsHealed { get; set; }
        public int TripleKills { get; set; }
        public long TrueDamageDealt { get; set; }
        public long TrueDamageDealtToChampions { get; set; }
        public long TrueDamageTaken { get; set; }
        public int TurretKills { get; set; }
        public int TurretsLost { get; set; }
        public int UnrealKills { get; set; }
        public int VisionScore { get; set; }
        public int VisionWardsBoughtInGame { get; set; }
        public int WardsKilled { get; set; }
        public int WardsPlaced { get; set; }
        public bool Win { get; set; }
    }
}
