using System.Collections.Generic;
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
        public Task AddGameTypeAsync(string playerId, string gameTypeId)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<Player>> GetAllAsync()
        {
            var url = $"api/{_maScoreClientConfiguration.PlayerResourceConfiguration.ResourceName}";
            var response = await _httpClient.GetAsync<List<Player>>(url);
            return response;
        }

        public Task<Player> GetPlayerAsync(string id)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<Player>> GetPlayersByGameTypeAsync(string gameTypeId)
        {
            throw new System.NotImplementedException();
        }

        public Task RemoveGameTypeAsync(string playerId, string gameTypeId)
        {
            throw new System.NotImplementedException();
        }
    }
}