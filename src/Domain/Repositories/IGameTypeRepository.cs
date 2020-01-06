using System.Threading.Tasks;
using MaScore.EloThereUI.Domain.Entities;

namespace MaScore.EloThereUI.Domain.Repositories
{
    public interface IGameTypeRepository
    {
        Task<GameType> GetAsync(string gameTypeId);
    }
}