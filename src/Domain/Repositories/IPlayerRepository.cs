using System.Collections.Generic;
using System.Threading.Tasks;
using MaScore.EloThereUI.Domain.Entities;

namespace MaScore.EloThereUI.Domain.Repositories
{
    /// <summary>
    /// Handle Operations for Player informations
    /// </summary>
    public interface IPlayerRepository
    {
        /// <summary>
        /// Get player by his id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
         Task<Player> GetPlayerAsync(string id);
         /// <summary>
         /// Get a list of player which played a gametype
         /// </summary>
         /// <param name="gameTypeId">GameType's id</param>
         /// <returns></returns>
         Task<List<Player>> GetPlayersByGameTypeAsync(string gameTypeId);
         /// <summary>
         /// Get all players
         /// </summary>
         /// <returns></returns>
         Task<List<Player>> GetAllAsync();
         /// <summary>
         /// Add a gametype to a player
         /// </summary>
         /// <param name="playerId"></param>
         /// <param name="gameTypeId"></param>
         /// <returns></returns>
         Task AddGameTypeAsync(string playerId, string gameTypeId);
         /// <summary>
         /// Remove a gametype from a player
         /// </summary>
         /// <param name="playerId"></param>
         /// <param name="gameTypeId"></param>
         /// <returns></returns>
         Task RemoveGameTypeAsync(string playerId, string gameTypeId);
    }
}