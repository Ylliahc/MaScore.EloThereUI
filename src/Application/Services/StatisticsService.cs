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
        private readonly IGameTypeRepository _gameTypeRepository;
        private readonly IScoreRepository _scoreRepository;

        public StatisticsService(
            IGameTypeRepository gameTypeRepository,
            IScoreRepository scoreRepository)
        {
            _gameTypeRepository = gameTypeRepository;
            _scoreRepository = scoreRepository;
        }

        public async Task<PlayerStatistics> GetPlayerStatistics(string playerId)
        {
            var gameTypes = await _gameTypeRepository.GetPlayerGametypes(playerId: playerId);
            var scores = new List<Score>();
            
            gameTypes.ForEach(
                async gameType => scores.AddRange(
                    await _scoreRepository.GetHistory(playerId: playerId, gameTypeId: gameType.Id, 0)
                )
            );
            
            var playerStatistics = new PlayerStatistics(){
                NumberGameTypes = gameTypes.Count,
                FirstGameDate = scores.Min( x => x.Date),
                LastGameDate = scores.Max(x => x.Date),
                NumberGamesPlayed = scores.Count(),
                TotalPoints = ComputeTotalPoints(scores)
            };
            return playerStatistics;
        }

        private int ComputeTotalPoints(List<Score> scores)
        {
            var scoresGrouped = scores.OrderByDescending(x => x.Date)
                                .GroupBy( x=> x.GameTypeId)
                                .ToDictionary( x=> x.Key, x => x.ToList());
                                
            int totalPoints = 0;
            foreach(var gameTypeId in scoresGrouped.Keys)
            {
                totalPoints += scoresGrouped[gameTypeId].FirstOrDefault()?.Value ?? 0;
            }

            return totalPoints;
        }
    }
}