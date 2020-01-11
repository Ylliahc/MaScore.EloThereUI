using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MaScore.EloThereUI.Domain.Entities;
using MaScore.EloThereUI.Domain.Repositories;
using MaScore.EloThereUI.Infrastructure.Configurations;
using Newtonsoft.Json;

namespace MaScore.EloThereUI.Infrastructure.Repositories
{
    public class GameTypeRepository : IGameTypeRepository
    {
        private readonly HttpClient _httpClient;
        private readonly MaScoreClientConfiguration _maScoreClientConfiguration;

        public GameTypeRepository(
            HttpClient httpClient,
            IOptions<MaScoreClientConfiguration> maScoreClientConfiguration)
        {
            _httpClient = httpClient;
            _maScoreClientConfiguration = maScoreClientConfiguration.Value;

            _httpClient.BaseAddress = new System.Uri(_maScoreClientConfiguration.Url);
        }
        public async Task<GameType> GetByPlayerIdAsync(string playerId)
        {
            if (string.IsNullOrWhiteSpace(playerId))
            {
                throw new System.ArgumentException("message", nameof(playerId));
            }

            var url = $"{_maScoreClientConfiguration.GameTypeResource.ResourceName}/{_maScoreClientConfiguration.GameTypeResource.GetByPlayerIdEndPoint}/{playerId}";
            var httpResponseMessage = await _httpClient.GetAsync(url);
            var toto = httpResponseMessage.EnsureSuccessStatusCode();
            
            return JsonConvert.DeserializeObject<GameType>( await toto.Content.ReadAsStringAsync());
        }

        public async Task<GameType> GetAsync(string gameTypeId)
        {
            if (string.IsNullOrWhiteSpace(gameTypeId))
            {
                throw new System.ArgumentException("message", nameof(gameTypeId));
            }

            var url = $"{_maScoreClientConfiguration.GameTypeResource.ResourceName}/{gameTypeId}";
            var httpResponseMessage = (await _httpClient.GetAsync(url)).EnsureSuccessStatusCode();
            
            return JsonConvert.DeserializeObject<GameType>( await httpResponseMessage.Content.ReadAsStringAsync());
        }
    }
}