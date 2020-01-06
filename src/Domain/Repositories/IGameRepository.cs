using System.Threading.Tasks;
using MaScore.EloThereUI.Domain.Entities;

namespace MaScore.EloThereUI.Domain.Repositories
{
    public interface IGameRepository
    {
         Task<Game> GetAsync(string id);
    }
}