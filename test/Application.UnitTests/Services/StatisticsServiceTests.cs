using FluentAssertions;
using MaScore.EloThereUI.Application.Services;
using Xunit;

namespace MaScore.EloThereUI.Application.UnitTests.Services
{
    public class StatisticsServiceTests : ServiceTestsBase
    {
        [Fact]
        public void GetPlayerStatistics_When_Expect()
        {
            //Arrange
            var playerExpectedStats = GetExpectedPlayerStatistics();
            var player = GetPlayer(playerExpectedStats);
            var scoreRepository = GetScoreRepository(playerExpectedStats, player);
            var playerRepository = GetPlayerRepository(playerExpectedStats);
            var statisticService = new StatisticsService(playerRepository: playerRepository,scoreRepository: scoreRepository);
            //Act
            var result = statisticService.GetPlayerStatistics("toto").Result;
            //Assert
            result.Should().BeEquivalentTo(playerExpectedStats);
        }
    }
}