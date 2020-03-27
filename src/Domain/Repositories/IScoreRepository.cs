using System.Threading.Tasks;
using MaScore.EloThereUI.Domain.Entities;

namespace MaScore.EloThereUI.Domain.Repositories
{
    public interface IScoreRepository
    {
        Task<Score> GetAsync(string scoreId);
    }
}