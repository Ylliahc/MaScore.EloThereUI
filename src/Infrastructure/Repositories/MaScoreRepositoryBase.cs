using MaScore.EloThereUI.Infrastructure.Clients;
using MaScore.EloThereUI.Infrastructure.Configurations;
using Microsoft.Extensions.Options;

namespace MaScore.EloThereUI.Infrastructure.Repositories
{
    public class MaScoreRepositoryBase
    {
        protected readonly MaScoreApiClient _httpClient;
        protected readonly MaScoreClientConfiguration _maScoreClientConfiguration;

        public MaScoreRepositoryBase(MaScoreApiClient httpClient, IOptions<MaScoreClientConfiguration> maScoreClientConfiguration)
        {
            _httpClient = httpClient;
            _maScoreClientConfiguration = maScoreClientConfiguration.Value;
        }
    }
}