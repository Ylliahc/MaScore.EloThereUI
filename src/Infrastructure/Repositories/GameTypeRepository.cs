using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MaScore.EloThereUI.Domain.Repositories;
using MaScore.EloThereUI.Infrastructure.Configurations;
using MaScore.EloThereUI.Infrastructure.Clients;
using AutoMapper;
using MaScore.EloThereUI.Infrastructure.Entities;
using System.Net;
using System.Collections.Generic;

namespace MaScore.EloThereUI.Infrastructure.Repositories
{
    public class GameTypeRepository : MaScoreRepositoryBase , IGameTypeRepository
    {

        public GameTypeRepository(
            MaScoreApiClient httpClient,
            IOptions<MaScoreClientConfiguration> maScoreClientConfiguration,
            IMapper mapper)
            : base(httpClient,maScoreClientConfiguration,mapper)
        {
            
        }
        public async Task<List<Domain.Entities.GameType>> GetPlayerGametypes(string playerId)
        {
            if (string.IsNullOrWhiteSpace(playerId))
            {
                throw new System.ArgumentException("message", nameof(playerId));
            }

            var url = $"{_maScoreClientConfiguration.GameTypeResource.ResourceName}/{_maScoreClientConfiguration.GameTypeResource.GetByPlayerIdEndPoint}/{WebUtility.UrlEncode(playerId)}";
            
            return _mapper.Map<List<Domain.Entities.GameType>>(await _httpClient.GetAsync<List<GameType>>(url));
        }

        public async Task<Domain.Entities.GameType> GetAsync(string gameTypeId)
        {
            if (string.IsNullOrWhiteSpace(gameTypeId))
            {
                throw new System.ArgumentException("message", nameof(gameTypeId));
            }

            var url = $"{_maScoreClientConfiguration.GameTypeResource.ResourceName}/{WebUtility.UrlEncode(gameTypeId)}";
            
            return _mapper.Map<Domain.Entities.GameType>(await _httpClient.GetAsync<GameType>(url));
        }
    }
}