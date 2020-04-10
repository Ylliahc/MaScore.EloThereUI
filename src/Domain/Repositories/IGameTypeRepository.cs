using System.Collections.Generic;
using System.Threading.Tasks;
using MaScore.EloThereUI.Domain.Entities;

namespace MaScore.EloThereUI.Domain.Repositories
{
    /// <summary>
    /// Repository interface for gametypes
    /// </summary>
    public interface IGameTypeRepository
    {
        Task<GameType> GetAsync(string gameTypeId);
        Task<List<GameType>> GetPlayerGametypes(string playerId);
    }
}