using Microsoft.EntityFrameworkCore.Migrations;

namespace LeagueStats.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Infos",
                columns: table => new
                {
                    InfoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameCreation = table.Column<long>(type: "bigint", nullable: false),
                    GameDuration = table.Column<long>(type: "bigint", nullable: false),
                    GameId = table.Column<long>(type: "bigint", nullable: false),
                    GameMode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GameName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GameStartTimestamp = table.Column<long>(type: "bigint", nullable: false),
                    GameType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GameVersion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MapId = table.Column<int>(type: "int", nullable: false),
                    PlatformId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QueueId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Infos", x => x.InfoId);
                });

            migrationBuilder.CreateTable(
                name: "Metadatas",
                columns: table => new
                {
                    MetadataId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataVersion = table.Column<int>(type: "int", nullable: false),
                    MatchId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Metadatas", x => x.MetadataId);
                });

            migrationBuilder.CreateTable(
                name: "StatPerks",
                columns: table => new
                {
                    StatPerksId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Defense = table.Column<int>(type: "int", nullable: false),
                    Flex = table.Column<int>(type: "int", nullable: false),
                    Offense = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatPerks", x => x.StatPerksId);
                });

            migrationBuilder.CreateTable(
                name: "Matches",
                columns: table => new
                {
                    MatchId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MetadataId = table.Column<int>(type: "int", nullable: true),
                    InfoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matches", x => x.MatchId);
                    table.ForeignKey(
                        name: "FK_Matches_Infos_InfoId",
                        column: x => x.InfoId,
                        principalTable: "Infos",
                        principalColumn: "InfoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Matches_Metadatas_MetadataId",
                        column: x => x.MetadataId,
                        principalTable: "Metadatas",
                        principalColumn: "MetadataId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Perks",
                columns: table => new
                {
                    PerkId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatPerksId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Perks", x => x.PerkId);
                    table.ForeignKey(
                        name: "FK_Perks_StatPerks_StatPerksId",
                        column: x => x.StatPerksId,
                        principalTable: "StatPerks",
                        principalColumn: "StatPerksId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Participants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Assists = table.Column<int>(type: "int", nullable: false),
                    BaronKills = table.Column<int>(type: "int", nullable: false),
                    BountyLevel = table.Column<int>(type: "int", nullable: false),
                    ChampExperience = table.Column<long>(type: "bigint", nullable: false),
                    ChampionId = table.Column<int>(type: "int", nullable: false),
                    ChampionName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConsumablesPurchased = table.Column<int>(type: "int", nullable: false),
                    DamageDealtToBuildings = table.Column<long>(type: "bigint", nullable: false),
                    DamageDealtToObjectives = table.Column<long>(type: "bigint", nullable: false),
                    DamageDealtToTurrets = table.Column<long>(type: "bigint", nullable: false),
                    DamageSelfMitigated = table.Column<long>(type: "bigint", nullable: false),
                    Deaths = table.Column<int>(type: "int", nullable: false),
                    DetectorWardsPlaced = table.Column<int>(type: "int", nullable: false),
                    DoubleKills = table.Column<int>(type: "int", nullable: false),
                    DragonKills = table.Column<int>(type: "int", nullable: false),
                    FirstBloodAssist = table.Column<bool>(type: "bit", nullable: false),
                    FirstBloodKill = table.Column<bool>(type: "bit", nullable: false),
                    FirstTowerAssist = table.Column<bool>(type: "bit", nullable: false),
                    FirstTowerKill = table.Column<bool>(type: "bit", nullable: false),
                    GameEndedInEarlySurrender = table.Column<bool>(type: "bit", nullable: false),
                    GameEndedInSurrender = table.Column<bool>(type: "bit", nullable: false),
                    GoldEarned = table.Column<long>(type: "bigint", nullable: false),
                    GoldSpent = table.Column<long>(type: "bigint", nullable: false),
                    IndividualPosition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InhibitorKills = table.Column<int>(type: "int", nullable: false),
                    InhibitorsLost = table.Column<int>(type: "int", nullable: false),
                    Item0 = table.Column<int>(type: "int", nullable: false),
                    Item1 = table.Column<int>(type: "int", nullable: false),
                    Item2 = table.Column<int>(type: "int", nullable: false),
                    Item3 = table.Column<int>(type: "int", nullable: false),
                    Item4 = table.Column<int>(type: "int", nullable: false),
                    Item5 = table.Column<int>(type: "int", nullable: false),
                    Item6 = table.Column<int>(type: "int", nullable: false),
                    ItemsPurchased = table.Column<int>(type: "int", nullable: false),
                    KillingSprees = table.Column<int>(type: "int", nullable: false),
                    Kills = table.Column<int>(type: "int", nullable: false),
                    Lane = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LargestCriticalStrike = table.Column<int>(type: "int", nullable: false),
                    LargestKillingSpree = table.Column<int>(type: "int", nullable: false),
                    LargestMultiKill = table.Column<int>(type: "int", nullable: false),
                    LongestTimeSpentLeveling = table.Column<int>(type: "int", nullable: false),
                    MagicDamageDealt = table.Column<long>(type: "bigint", nullable: false),
                    MagicDamageDealtToChampions = table.Column<long>(type: "bigint", nullable: false),
                    MagicDamageTaken = table.Column<long>(type: "bigint", nullable: false),
                    NeutralMinionsKilled = table.Column<int>(type: "int", nullable: false),
                    NexusKills = table.Column<int>(type: "int", nullable: false),
                    NexusLost = table.Column<int>(type: "int", nullable: false),
                    ObjectivesStolen = table.Column<int>(type: "int", nullable: false),
                    ObjectivesStolenAssists = table.Column<int>(type: "int", nullable: false),
                    ParticipantId = table.Column<int>(type: "int", nullable: false),
                    PentaKills = table.Column<int>(type: "int", nullable: false),
                    PerksPerkId = table.Column<int>(type: "int", nullable: true),
                    PhysicalDamageDealt = table.Column<long>(type: "bigint", nullable: false),
                    PhysicalDamageDealtToChampions = table.Column<long>(type: "bigint", nullable: false),
                    PhysicalDamageTaken = table.Column<long>(type: "bigint", nullable: false),
                    ProfileIcon = table.Column<int>(type: "int", nullable: false),
                    Puuid = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuadraKills = table.Column<int>(type: "int", nullable: false),
                    RiotIdName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RiotIdTagLine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SightWardsBoughtInGame = table.Column<int>(type: "int", nullable: false),
                    Spell1Casts = table.Column<int>(type: "int", nullable: false),
                    Spell2Casts = table.Column<int>(type: "int", nullable: false),
                    Spell3Casts = table.Column<int>(type: "int", nullable: false),
                    Spell4Casts = table.Column<int>(type: "int", nullable: false),
                    Summoner1Casts = table.Column<int>(type: "int", nullable: false),
                    Summoner1Id = table.Column<int>(type: "int", nullable: false),
                    Summoner2Casts = table.Column<int>(type: "int", nullable: false),
                    Summoner2Id = table.Column<int>(type: "int", nullable: false),
                    SummonerId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SummonerLevel = table.Column<int>(type: "int", nullable: false),
                    SummonerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TeamEarlySurrendered = table.Column<bool>(type: "bit", nullable: false),
                    TeamId = table.Column<int>(type: "int", nullable: false),
                    TeamPosition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TimeCCingOthers = table.Column<long>(type: "bigint", nullable: false),
                    TimePlayed = table.Column<long>(type: "bigint", nullable: false),
                    TotalDamageDealt = table.Column<long>(type: "bigint", nullable: false),
                    TotalDamageDealtToChampions = table.Column<long>(type: "bigint", nullable: false),
                    TotalDamageShieldedOnTeammates = table.Column<long>(type: "bigint", nullable: false),
                    TotalDamageTaken = table.Column<long>(type: "bigint", nullable: false),
                    TotalHeal = table.Column<long>(type: "bigint", nullable: false),
                    TotalHealsOnTeammates = table.Column<long>(type: "bigint", nullable: false),
                    TotalMinionsKilled = table.Column<int>(type: "int", nullable: false),
                    TotalTimeCCDealt = table.Column<int>(type: "int", nullable: false),
                    TotalTimeSpentDead = table.Column<long>(type: "bigint", nullable: false),
                    TotalUnitsHealed = table.Column<int>(type: "int", nullable: false),
                    TripleKills = table.Column<int>(type: "int", nullable: false),
                    TrueDamageDealt = table.Column<long>(type: "bigint", nullable: false),
                    TrueDamageDealtToChampions = table.Column<long>(type: "bigint", nullable: false),
                    TrueDamageTaken = table.Column<long>(type: "bigint", nullable: false),
                    TurretKills = table.Column<int>(type: "int", nullable: false),
                    TurretsLost = table.Column<int>(type: "int", nullable: false),
                    UnrealKills = table.Column<int>(type: "int", nullable: false),
                    VisionScore = table.Column<int>(type: "int", nullable: false),
                    VisionWardsBoughtInGame = table.Column<int>(type: "int", nullable: false),
                    WardsKilled = table.Column<int>(type: "int", nullable: false),
                    WardsPlaced = table.Column<int>(type: "int", nullable: false),
                    Win = table.Column<bool>(type: "bit", nullable: false),
                    InfoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Participants_Infos_InfoId",
                        column: x => x.InfoId,
                        principalTable: "Infos",
                        principalColumn: "InfoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Participants_Perks_PerksPerkId",
                        column: x => x.PerksPerkId,
                        principalTable: "Perks",
                        principalColumn: "PerkId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Styles",
                columns: table => new
                {
                    StyleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StyleNumber = table.Column<int>(type: "int", nullable: false),
                    PerkId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Styles", x => x.StyleId);
                    table.ForeignKey(
                        name: "FK_Styles_Perks_PerkId",
                        column: x => x.PerkId,
                        principalTable: "Perks",
                        principalColumn: "PerkId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Selections",
                columns: table => new
                {
                    SelectionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Perk = table.Column<int>(type: "int", nullable: false),
                    Var1 = table.Column<int>(type: "int", nullable: false),
                    Var2 = table.Column<int>(type: "int", nullable: false),
                    Var3 = table.Column<int>(type: "int", nullable: false),
                    StyleId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Selections", x => x.SelectionId);
                    table.ForeignKey(
                        name: "FK_Selections_Styles_StyleId",
                        column: x => x.StyleId,
                        principalTable: "Styles",
                        principalColumn: "StyleId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Matches_InfoId",
                table: "Matches",
                column: "InfoId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_MetadataId",
                table: "Matches",
                column: "MetadataId");

            migrationBuilder.CreateIndex(
                name: "IX_Participants_InfoId",
                table: "Participants",
                column: "InfoId");

            migrationBuilder.CreateIndex(
                name: "IX_Participants_PerksPerkId",
                table: "Participants",
                column: "PerksPerkId");

            migrationBuilder.CreateIndex(
                name: "IX_Perks_StatPerksId",
                table: "Perks",
                column: "StatPerksId");

            migrationBuilder.CreateIndex(
                name: "IX_Selections_StyleId",
                table: "Selections",
                column: "StyleId");

            migrationBuilder.CreateIndex(
                name: "IX_Styles_PerkId",
                table: "Styles",
                column: "PerkId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Matches");

            migrationBuilder.DropTable(
                name: "Participants");

            migrationBuilder.DropTable(
                name: "Selections");

            migrationBuilder.DropTable(
                name: "Metadatas");

            migrationBuilder.DropTable(
                name: "Infos");

            migrationBuilder.DropTable(
                name: "Styles");

            migrationBuilder.DropTable(
                name: "Perks");

            migrationBuilder.DropTable(
                name: "StatPerks");
        }
    }
}
