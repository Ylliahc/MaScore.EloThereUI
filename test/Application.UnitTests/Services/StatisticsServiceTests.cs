using FluentAssertions;
using MaScore.EloThereUI.Application.Services;
using Xunit;

namespace MaScore.EloThereUI.Application.UnitTests.Services
{
    public class StatisticsServiceTests : ServiceTestsBase
    {
        [Fact]
        public void GetPlayerStatistics_WhenNominalCase_ExpectNoError()
        {
            //Arrange
            var playerExpectedStats = GetExpectedPlayerStatistics();
            var gameTypeRepository = GetGameTypeRepository(playerExpectedStats);
            var gameTypes = gameTypeRepository.GetPlayerGametypes(string.Empty).Result;
            var scoreRepository = GetScoreRepository(playerExpectedStats, gameTypes);
            var statisticService = new StatisticsService(gameTypeRepository,scoreRepository: scoreRepository);
            //Act
            var result = statisticService.GetPlayerStatisticsAsync("toto").Result;
            //Assert
            result.Should().BeEquivalentTo(playerExpectedStats);
        }

        [Fact]
        public void GetPlayerStatistics_WhenNoGame_ExpectNoError()
        {
            //Arrange
            var playerExpectedStats = GetExpectedPlayerStatistics();
            var gameTypeRepository = GetGameTypeRepository(playerExpectedStats);
            var gameTypes = gameTypeRepository.GetPlayerGametypes(string.Empty).Result;
            var scoreRepository = GetScoreRepository(playerExpectedStats, gameTypes);
            var statisticService = new StatisticsService(gameTypeRepository,scoreRepository: scoreRepository);
            //Act
            var result = statisticService.GetPlayerStatisticsAsync("toto").Result;
            //Assert
            result.Should().BeEquivalentTo(playerExpectedStats);
        }
    }
}