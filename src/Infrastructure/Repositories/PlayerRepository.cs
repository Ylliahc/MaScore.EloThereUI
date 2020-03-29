using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using MaScore.EloThereUI.Domain.Repositories;
using MaScore.EloThereUI.Infrastructure.Clients;
using MaScore.EloThereUI.Infrastructure.Configurations;
using MaScore.EloThereUI.Infrastructure.Entities;
using Microsoft.Extensions.Options;

namespace MaScore.EloThereUI.Infrastructure.Repositories
{
    public class PlayerRepository : MaScoreRepositoryBase ,IPlayerRepository
    {

        public PlayerRepository(
            MaScoreApiClient httpClient,
            IOptions<MaScoreClientConfiguration> maScoreClientConfiguration,
            IMapper mapper)
            : base(httpClient,maScoreClientConfiguration, mapper)
        {

        }   
        public async Task AddGameTypeAsync(string playerId, string gameTypeId)
        {
            if (string.IsNullOrWhiteSpace(playerId))
            {
                throw new System.ArgumentException("message", nameof(playerId));
            }

            if (string.IsNullOrWhiteSpace(gameTypeId))
            {
                throw new System.ArgumentException("message", nameof(gameTypeId));
            }
            var playerIdEncoded = WebUtility.UrlEncode(value: playerId);
            var gameTypeIdEncoded =  WebUtility.UrlEncode(value: gameTypeId);
            var url = $"api/{_maScoreClientConfiguration.PlayerResourceConfiguration.ResourceName}/{playerIdEncoded}/{_maScoreClientConfiguration.PlayerResourceConfiguration.PutAddGameTypeEndpoint}?gameTypeId={gameTypeIdEncoded}";
            await _httpClient.PutAsync(url);
        }

        public async Task<List<Domain.Entities.Player>> GetAllAsync()
        {
            var url = $"{_maScoreClientConfiguration.PlayerResourceConfiguration.ResourceName}";
            var response = await _httpClient.GetAsync<List<Player>>(url);
            return _mapper.Map<List<Domain.Entities.Player>>(response);
        }

        public async Task<Domain.Entities.Player> GetPlayerAsync(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new System.ArgumentException("message", nameof(id));
            }

            var url = $"{_maScoreClientConfiguration.PlayerResourceConfiguration.ResourceName}/{id}";
            return _mapper.Map<Domain.Entities.Player>(await _httpClient.GetAsync<Player>(url));
        }

        public async Task<List<Domain.Entities.Player>> GetPlayersByGameTypeAsync(string gameTypeId)
        {
            if (string.IsNullOrWhiteSpace(gameTypeId))
            {
                throw new System.ArgumentException("message", nameof(gameTypeId));
            }

            var url = $"{_maScoreClientConfiguration.PlayerResourceConfiguration.ResourceName}/{_maScoreClientConfiguration.PlayerResourceConfiguration.GetByGameTypeIdEndpoint}";
            return _mapper.Map<List<Domain.Entities.Player>>(await _httpClient.GetAsync<List<Player>>(url));
        }

        public async Task RemoveGameTypeAsync(string playerId, string gameTypeId)
        {
            var playerIdEncoded = WebUtility.UrlEncode(value: playerId);
            var gameTypeIdEncoded =  WebUtility.UrlEncode(value: gameTypeId);
            var url = $"{_maScoreClientConfiguration.PlayerResourceConfiguration.ResourceName}/{playerIdEncoded}/{_maScoreClientConfiguration.PlayerResourceConfiguration.PutRemoveGameTypeEndpoint}?gameTypeId={gameTypeIdEncoded}";
            await _httpClient.PutAsync(url);
        }
    }
}