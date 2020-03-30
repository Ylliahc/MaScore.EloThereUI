using MaScore.EloThereUI.Domain.Entities;
using MaScore.EloThereUI.Domain.Repositories;

namespace MaScore.EloThereUI.Application.Services
{
    /// <summary>
    /// Statistics service
    /// </summary>
    public class StatisticsService
    {
        private readonly IPlayerRepository _playerRepository;
        private readonly IScoreRepository _scoreRepository;

        public StatisticsService(
            IPlayerRepository playerRepository,
            IScoreRepository scoreRepository)
        {
            _playerRepository = playerRepository;
            _scoreRepository = scoreRepository;
        }

        public PlayerStatistics GetPlayerStatistics(string playerId)
        {
            throw new System.NotImplementedException();
        }
    }
}