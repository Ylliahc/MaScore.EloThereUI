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
            var playerIdEncoded = WebUtility.UrlEncode(playerId);
            var gameTypeIdEncoded =  WebUtility.UrlEncode(gameTypeId);
            var url = $"api/{_maScoreClientConfiguration.PlayerResourceConfiguration.ResourceName}/{playerIdEncoded}/{_maScoreClientConfiguration.PlayerResourceConfiguration.PutAddGameTypeEndpoint}?gameTypeId={gameTypeIdEncoded}";
            
        }

        public async Task<List<Player>> GetAllAsync()
        {
            var url = $"api/{_maScoreClientConfiguration.PlayerResourceConfiguration.ResourceName}";
            var response = await _httpClient.GetAsync<List<Player>>(url);
            return response;
        }

        public async Task<Player> GetPlayerAsync(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new System.ArgumentException("message", nameof(id));
            }

            var url = $"api/{_maScoreClientConfiguration.PlayerResourceConfiguration.ResourceName}/{id}";
            return await _httpClient.GetAsync<Player>(id);
        }

        public async Task<List<Player>> GetPlayersByGameTypeAsync(string gameTypeId)
        {
            if (string.IsNullOrWhiteSpace(gameTypeId))
            {
                throw new System.ArgumentException("message", nameof(gameTypeId));
            }

            var url = $"api/{_maScoreClientConfiguration.PlayerResourceConfiguration.ResourceName}/{_maScoreClientConfiguration.PlayerResourceConfiguration.GetByGameTypeIdEndpoint}";
            return await _httpClient.GetAsync<List<Player>>(url);
        }

        public async Task RemoveGameTypeAsync(string playerId, string gameTypeId)
        {
            throw new System.NotImplementedException();
        }
    }
}