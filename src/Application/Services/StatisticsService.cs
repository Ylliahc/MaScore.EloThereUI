using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task<PlayerStatistics> GetPlayerStatistics(string playerId)
        {
            var player = await _playerRepository.GetPlayerAsync(id: playerId);
            var scores = new List<Score>();
            player.GameTypes.ForEach(
                async gameType => scores.AddRange(
                    await _scoreRepository.GetHistory(playerId: playerId, gameTypeId: gameType.Id, 0)
                )
            );

            var playerStatistics = new PlayerStatistics(){
                NumberGameTypes = player.GameTypes.Count,
                FirstGameDate = scores.Min( x => x.Date),
                LastGameDate = scores.Max(x => x.Date),
                NumberGamesPlayed = scores.Count()
            };
            return playerStatistics;
        }
    }
}