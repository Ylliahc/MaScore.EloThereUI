using System.Net.Http;
using System.Threading.Tasks;
using MaScore.EloThereUI.Domain.Entities;
using MaScore.EloThereUI.Domain.Repositories;

namespace MaScore.EloThereUI.Infrastructure.Repositories
{
    public class GameTypeRepository : IGameTypeRepository
    {
        private readonly HttpClient _httpClient;
        public GameTypeRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public Task<GameType> GetAsync(string gameTypeId)
        {
            throw new System.NotImplementedException();
        }
    }
}