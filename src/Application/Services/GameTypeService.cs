using System.Threading.Tasks;
using MaScore.EloThereUI.Domain.Entities;
using MaScore.EloThereUI.Domain.Repositories;

namespace MaScore.EloThereUI.Application.Services
{
    public class GameTypeService
    {
        private readonly IGameTypeRepository _gameTypeRepository;

        public GameTypeService(IGameTypeRepository gameTypeRepository)
        {
            _gameTypeRepository = gameTypeRepository;
        }

        public async Task<GameType> Get(string gameTypeId)
        {
            return await _gameTypeRepository.GetAsync(gameTypeId);
        }
    }
}