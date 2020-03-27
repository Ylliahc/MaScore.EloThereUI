using System.Threading.Tasks;
using MaScore.EloThereUI.Domain.Entities;
using MaScore.EloThereUI.Domain.Repositories;
using MaScore.EloThereUI.Infrastructure.Clients;
using MaScore.EloThereUI.Infrastructure.Configurations;
using Microsoft.Extensions.Options;

namespace MaScore.EloThereUI.Infrastructure.Repositories
{
    /// <summary>
    /// Score repository
    /// </summary>
    public class ScoreRepository : MaScoreRepositoryBase, IScoreRepository
    {
        public ScoreRepository(MaScoreApiClient httpClient, IOptions<MaScoreClientConfiguration> maScoreClientConfiguration) : base(httpClient, maScoreClientConfiguration)
        {
        }

        public async Task<Score> GetAsync(string scoreId)
        {
            var url = $"{_maScoreClientConfiguration.ScoreResourceConfiguration.ResourceName}/{scoreId}";
            return await _httpClient.GetAsync<Score>(url);
        }
    }
}