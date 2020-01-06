using System.Collections.Generic;
using System.Threading.Tasks;
using MaScore.EloThereUI.Domain.Entities;

namespace MaScore.EloThereUI.Domain.Repositories
{
    public interface IPlayerRepository
    {
         Task<Player> GetPlayerAsync(string id);
         Task<List<Player>> GetPlayersByGameTypeAsync(string gameTypeId);
         Task<List<Player>> GetAllAsync();
         Task AddGameTypeAsync(string playerId, string gameTypeId);
         Task RemoveGameTypeAsync(string playerId, string gameTypeId);
    }
}