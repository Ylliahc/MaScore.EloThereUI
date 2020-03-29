using AutoMapper;
using MaScore.EloThereUI.Infrastructure.Clients;
using MaScore.EloThereUI.Infrastructure.Configurations;
using Microsoft.Extensions.Options;

namespace MaScore.EloThereUI.Infrastructure.Repositories
{
    public class MaScoreRepositoryBase
    {
        protected readonly MaScoreApiClient _httpClient;
        protected readonly IMapper _mapper;
        protected readonly MaScoreClientConfiguration _maScoreClientConfiguration;

        public MaScoreRepositoryBase(
            MaScoreApiClient httpClient,
            IOptions<MaScoreClientConfiguration> maScoreClientConfiguration,
            IMapper mapper)
        {
            _httpClient = httpClient;
            _mapper = mapper;
            _maScoreClientConfiguration = maScoreClientConfiguration.Value;
        }
    }
}