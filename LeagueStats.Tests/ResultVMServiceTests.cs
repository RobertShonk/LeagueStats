using System;
using System.Collections.Generic;
using System.Text;
using LeagueStats.Services;
using LeagueStats.Models;
using LeagueStats.Data.Entities;
using Xunit;

namespace LeagueStats.Tests {
    public class ResultVMServiceTests {

        [Theory]
        [InlineData(1, "/images/spell/SummonerBoost.png")]
        [InlineData(7, "/images/spell/SummonerHeal.png")]
        [InlineData(32, "/images/spell/SummonerSnowball.png")]
        public void SetUserSummonerSpellsUrls_ShouldBeEqualToGivenUrl(int testId, string expectedUrl)
        {
            // Arrange
            Models.MatchDto match = new Models.MatchDto() { Summoner1Id = testId };
            string expected = expectedUrl;

            // Act
            ResultVMService rvmService = new ResultVMService();
            rvmService.SetUserSummonerSpellsUrls(match);

            // Assert
            Assert.Equal(match.Summoner1ImageUrl, expected);
        }

        [Fact]
        public void CalcTotalTeamKills_ShouldEqualSix()
        {
            // Arrange
            int teamId = 100;
            List<Data.Entities.Participant> participants = new List<Data.Entities.Participant>() {
                new Models.ParticipantDto() { Kills = 2, TeamId = 100 },
                new Models.ParticipantDto() { Kills = 2, TeamId = 100 },
                new Models.ParticipantDto() { Kills = 2, TeamId = 200 },
                new Models.ParticipantDto() { Kills = 2, TeamId = 200 },
                new Models.ParticipantDto() { Kills = 2, TeamId = 100 }
            };

            int expected = 6;

            // Act
            ResultVMService rvmService = new ResultVMService();
            int actual = rvmService.CalcTotalTeamKills(participants, teamId);

            // Assert
            Assert.Equal(actual, expected);
        }

        [Fact]
        public void CalcKillParticipation_ShouldEqualGivenKP()
        {
            int totalTeamKills = 39;
            Models.ParticipantDto participant = new Models.ParticipantDto() { Kills = 6, Assists = 19 };
            double expected = (double)(participant.Kills + participant.Assists) / (double)totalTeamKills;

            ResultVMService rvmService = new ResultVMService();
            double actual = rvmService.CalcKillParticipation(totalTeamKills, participant);

            Assert.Equal(actual, expected);

        }
    }
}
