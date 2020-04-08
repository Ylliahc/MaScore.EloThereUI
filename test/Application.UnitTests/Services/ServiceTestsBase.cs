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
        public IScoreRepository GetScoreRepository(PlayerStatistics playerExpectedStats, Player player)
        {
            var repositoryMock = new Mock<IScoreRepository>();

            repositoryMock.Setup(
                x => x.GetHistory(
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<int>()))
                .ReturnsAsync(GetScores(playerExpectedStats
                    ,player));

            return repositoryMock.Object;
        }

        public IPlayerRepository GetPlayerRepository(PlayerStatistics playerExpectedStats)
        {
            var repositoryMock = new Mock<IPlayerRepository>();
            repositoryMock.Setup(x => x.GetPlayerAsync(It.IsAny<string>()))
                .ReturnsAsync(GetPlayer(playerExpectedStats));

            return repositoryMock.Object;
        }

        public PlayerStatistics GetExpectedPlayerStatistics()
        {
            var fixture = new Fixture();

            var firstDate = new DateTime(2020,06,01);

            return new PlayerStatistics()
            {
                FirstGameDate = firstDate,
                LastGameDate = firstDate.AddMonths(6),
                NumberGamesPlayed = 6,
                NumberGameTypes = 3,
                TotalPoints = 100
            };
        }

        public List<Score> GetScores(PlayerStatistics expected,Player player)
        {
            var fixture = new Fixture();

            var gameTypes = fixture.CreateMany<string>(expected.NumberGameTypes).ToList();

            var scores = fixture.CreateMany<Score>(expected.NumberGamesPlayed).ToList();

            scores[0].GameTypeId = player.GameTypes[0].Id;
            scores[1].GameTypeId = player.GameTypes[1].Id;
            scores[2].GameTypeId = player.GameTypes[2].Id;
            scores[3].GameTypeId = player.GameTypes[0].Id;
            scores[4].GameTypeId = player.GameTypes[1].Id;
            scores[5].GameTypeId = player.GameTypes[2].Id;

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

        public Player GetPlayer(PlayerStatistics expected)
        {
            var fixture = new Fixture();
            var player = new Player()
            {
                LastName = "Titi",
                FirstName = "Toto",
                GameTypes = fixture.CreateMany<GameType>(expected.NumberGameTypes).ToList()
            };
            return player;
        }
    }
}