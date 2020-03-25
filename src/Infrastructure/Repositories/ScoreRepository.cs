using MaScore.EloThereUI.Infrastructure.Clients;
using MaScore.EloThereUI.Infrastructure.Configurations;
using Microsoft.Extensions.Options;

namespace MaScore.EloThereUI.Infrastructure.Repositories
{
    /// <summary>
    /// Score repository
    /// </summary>
    public class ScoreRepository : MaScoreRepositoryBase
    {
        public ScoreRepository(MaScoreApiClient httpClient, IOptions<MaScoreClientConfiguration> maScoreClientConfiguration) : base(httpClient, maScoreClientConfiguration)
        {
        }
    }
}