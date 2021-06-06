using System;
using System.Collections.Generic;
using System.Text;
using LeagueStats.Services;
using LeagueStats.Models;
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
            Match match = new Match() { Summoner1Id = testId };
            string expected = expectedUrl;

            // Act
            ResultVMService.SetUserSummonerSpellsUrls(match);

            // Assert
            Assert.Equal(match.Summoner1ImageUrl, expected);
        }

    }
}
