using System.Collections.Generic;
using System.Threading.Tasks;
using MaScore.EloThereUI.Domain.Entities;

namespace MaScore.EloThereUI.Domain.Repositories
{
    /// <summary>
    /// Score repository
    /// </summary>
    public interface IScoreRepository
    {
        /// <summary>
        /// Get a score with his id
        /// </summary>
        /// <param name="scoreId"></param>
        /// <returns></returns>
        Task<Score> GetAsync(string scoreId);
        /// <summary>
        /// Get score history
        /// </summary>
        /// <param name="playerId">Player id</param>
        /// <param name="gameTypeId">Game type id</param>
        /// <param name="limit">how many scores to take back in time</param>
        /// <returns></returns>
        Task<List<Score>> GetHistory(string playerId, string gameTypeId, int limit);
    }
}