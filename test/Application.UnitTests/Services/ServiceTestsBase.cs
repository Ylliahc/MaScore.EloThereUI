using System;
using System.Collections.Generic;
using System.Linq;
using AutoFixture;
using MaScore.EloThereUI.Domain.Entities;
using MaScore.EloThereUI.Domain.Repositories;
using Moq;

namespace MaScore.EloThereUI.Application.UnitTests.Services
{
    /// <summary>
    /// Contains all mock preparation for services tests
    /// </summary>
    public class ServiceTestsBase
    {
        public IScoreRepository GetScoreRepository(PlayerStatistics playerExpectedStats, List<GameType> gameTypes)
        {
            var repositoryMock = new Mock<IScoreRepository>();
            var scores = GetScores(playerExpectedStats
                    ,gameTypes);
            var fixture = new Fixture();
            repositoryMock.Setup(
                x => x.GetHistory(
                    It.IsAny<string>(),
                    gameTypes[0].Id,
                    It.IsAny<int>()))
                .ReturnsAsync(scores.Where(s => s.GameTypeId == gameTypes[0].Id).ToList());
            
            repositoryMock.Setup(
                x => x.GetHistory(
                    It.IsAny<string>(),
                    gameTypes[1].Id,
                    It.IsAny<int>()))
                .ReturnsAsync(scores.Where(s => s.GameTypeId == gameTypes[1].Id).ToList());

            repositoryMock.Setup(
                x => x.GetHistory(
                    It.IsAny<string>(),
                    gameTypes[2].Id,
                    It.IsAny<int>()))
                .ReturnsAsync(scores.Where(s => s.GameTypeId == gameTypes[2].Id).ToList());

            return repositoryMock.Object;
        }

        public IGameTypeRepository GetGameTypeRepository(PlayerStatistics playerExpectedStats)
        {
            var repositoryMock = new Mock<IGameTypeRepository>();
            var fixture = new Fixture();
            repositoryMock.Setup( x => x.GetPlayerGametypes(It.IsAny<string>()))
                .ReturnsAsync(fixture.CreateMany<GameType>(playerExpectedStats.NumberGameTypes).ToList());

            return repositoryMock.Object;
        }

        public PlayerStatistics GetExpectedPlayerStatistics()
        {
            var fixture = new Fixture();

            var firstDate = new DateTime(2020, 06, 01);

            return new PlayerStatistics()
            {
                FirstGameDate = firstDate,
                LastGameDate = firstDate.AddMonths(6),
                NumberGamesPlayed = 6,
                NumberGameTypes = 3,
                TotalPoints = 100
            };
        }

        public List<Score> GetScores(PlayerStatistics expected,List<GameType> GameTypes)
        {
            var fixture = new Fixture();

            var gameTypes = fixture.CreateMany<string>(expected.NumberGameTypes).ToList();

            var scores = fixture.CreateMany<Score>(expected.NumberGamesPlayed).ToList();

            scores[0].GameTypeId = GameTypes[0].Id;
            scores[1].GameTypeId = GameTypes[1].Id;
            scores[2].GameTypeId = GameTypes[2].Id;
            scores[3].GameTypeId = GameTypes[0].Id;
            scores[4].GameTypeId = GameTypes[1].Id;
            scores[5].GameTypeId = GameTypes[2].Id;

            scores[0].Date = expected.FirstGameDate.AddDays(1);
            scores[1].Date = expected.FirstGameDate.AddDays(2);
            scores[2].Date = expected.FirstGameDate.AddDays(3);
            scores[3].Date = expected.LastGameDate;
            scores[4].Date = expected.FirstGameDate;
            scores[5].Date = expected.FirstGameDate.AddDays(4);

            scores[0].Value = 0;
            scores[1].Value = 25;
            scores[2].Value = 0;
            scores[3].Value = 50;
            scores[4].Value = 0;
            scores[5].Value = 25;

            return scores;
        }
    }
}