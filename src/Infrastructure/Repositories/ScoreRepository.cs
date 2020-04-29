using System.Collections.Generic;
using System.Net;
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
            var url = $"{_maScoreClientConfiguration.ScoreResource.ResourceName}/{WebUtility.UrlEncode(scoreId)}";
            return _mapper.Map<Domain.Entities.Score>(await _httpClient.GetAsync<Entities.Score>(url));
        }

        public async Task<List<Domain.Entities.Score>> GetHistory(string playerId, string gameTypeId, int limit)
        {
            var url = string.Format(format: "{0}/{1}?gameTypeId={2}&playerId={3}&last={4}",
                _maScoreClientConfiguration.ScoreResource.ResourceName,
                _maScoreClientConfiguration.ScoreResource.HistoryEndpoint,
                WebUtility.UrlEncode(gameTypeId),
                WebUtility.UrlEncode(playerId),
                WebUtility.UrlEncode(limit.ToString())
                );
            return _mapper.Map<List<Domain.Entities.Score>>(await _httpClient.GetAsync<List<Entities.Score>>(url));
        }
    }
}