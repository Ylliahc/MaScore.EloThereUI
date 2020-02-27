using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using MaScore.EloThereUI.Domain.Entities;
using MaScore.EloThereUI.Domain.Repositories;
using MaScore.EloThereUI.Infrastructure.Clients;
using MaScore.EloThereUI.Infrastructure.Configurations;
using Microsoft.Extensions.Options;

namespace MaScore.EloThereUI.Infrastructure.Repositories
{
    public class PlayerRepository : MaScoreRepositoryBase ,IPlayerRepository
    {

        public PlayerRepository(
            MaScoreApiClient httpClient,
            IOptions<MaScoreClientConfiguration> maScoreClientConfiguration) : base(httpClient,maScoreClientConfiguration)
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
            var url = $"api/{_maScoreClientConfiguration.PlayerResource.ResourceName}/{playerIdEncoded}/{_maScoreClientConfiguration.PlayerResource.PutAddGameTypeEndpoint}?gameTypeId={gameTypeIdEncoded}";
            await _httpClient.PutAsync(url);
        }

        public async Task<List<Player>> GetAllAsync()
        {
            var url = $"{_maScoreClientConfiguration.PlayerResource.ResourceName}";
            var response = await _httpClient.GetAsync<List<Player>>(url);
            return response;
        }

        public async Task<Player> GetPlayerAsync(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new System.ArgumentException("message", nameof(id));
            }

            var url = $"{_maScoreClientConfiguration.PlayerResource.ResourceName}/{id}";
            return await _httpClient.GetAsync<Player>(url);
        }

        public async Task<List<Player>> GetPlayersByGameTypeAsync(string gameTypeId)
        {
            if (string.IsNullOrWhiteSpace(gameTypeId))
            {
                throw new System.ArgumentException("message", nameof(gameTypeId));
            }

            var url = $"{_maScoreClientConfiguration.PlayerResource.ResourceName}/{_maScoreClientConfiguration.PlayerResource.GetByGameTypeIdEndpoint}";
            return await _httpClient.GetAsync<List<Player>>(url);
        }

        public async Task RemoveGameTypeAsync(string playerId, string gameTypeId)
        {
            var playerIdEncoded = WebUtility.UrlEncode(value: playerId);
            var gameTypeIdEncoded =  WebUtility.UrlEncode(value: gameTypeId);
            var url = $"{_maScoreClientConfiguration.PlayerResource.ResourceName}/{playerIdEncoded}/{_maScoreClientConfiguration.PlayerResource.PutRemoveGameTypeEndpoint}?gameTypeId={gameTypeIdEncoded}";
            await _httpClient.PutAsync(url);
        }
    }
}