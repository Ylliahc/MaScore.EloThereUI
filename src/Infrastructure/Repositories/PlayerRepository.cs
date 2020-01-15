using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using MaScore.EloThereUI.Domain.Entities;
using MaScore.EloThereUI.Domain.Repositories;
using MaScore.EloThereUI.Infrastructure.Configurations;
using Microsoft.Extensions.Options;

namespace MaScore.EloThereUI.Infrastructure.Repositories
{
    public class PlayerRepository : MaScoreRepositoryBase ,IPlayerRepository
    {

        public PlayerRepository(
            HttpClient httpClient,
            IOptions<MaScoreClientConfiguration> maScoreClientConfiguration) : base(httpClient,maScoreClientConfiguration)
        {

        }   
        public Task AddGameTypeAsync(string playerId, string gameTypeId)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<Player>> GetAllAsync()
        {
            throw new System.NotImplementedException();
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