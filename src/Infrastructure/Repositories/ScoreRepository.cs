using System.Threading.Tasks;
using AutoMapper;
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
        public ScoreRepository(
            MaScoreApiClient httpClient,
            IOptions<MaScoreClientConfiguration> maScoreClientConfiguration,
            IMapper mapper) 
            : base(httpClient, maScoreClientConfiguration, mapper)
        {
        }

        public async Task<Domain.Entities.Score> GetAsync(string scoreId)
        {
            var url = $"{_maScoreClientConfiguration.ScoreResource.ResourceName}/{scoreId}";
            return _mapper.Map<Domain.Entities.Score>(await _httpClient.GetAsync<Entities.Score>(url));
        }
    }
}