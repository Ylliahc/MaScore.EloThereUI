using System.Net.Http;
using MaScore.EloThereUI.Infrastructure.Configurations;
using Microsoft.Extensions.Options;

namespace MaScore.EloThereUI.Infrastructure.Repositories
{
    public class MaScoreRepositoryBase
    {
        protected readonly HttpClient _httpClient;
        protected readonly MaScoreClientConfiguration _maScoreClientConfiguration;

        public MaScoreRepositoryBase(HttpClient httpClient, IOptions<MaScoreClientConfiguration> maScoreClientConfiguration)
        {
            _httpClient = httpClient;
            _maScoreClientConfiguration = maScoreClientConfiguration.Value;

            _httpClient.BaseAddress = new System.Uri(_maScoreClientConfiguration.Url);
        }
    }
}