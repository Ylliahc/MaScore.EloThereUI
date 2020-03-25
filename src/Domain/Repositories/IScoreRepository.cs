using MaScore.EloThereUI.Domain.Entities;

namespace MaScore.EloThereUI.Domain.Repositories
{
    public interface IScoreRepository
    {
        Score GetAsync(string scoreId);
    }
}