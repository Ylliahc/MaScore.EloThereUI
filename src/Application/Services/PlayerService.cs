using System.Threading.Tasks;
using MaScore.EloThereUI.Domain.Entities;
using MaScore.EloThereUI.Domain.Repositories;

namespace MaScore.EloThereUI.Application.Services
{
    public class PlayerService
    {
        public PlayerService(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        public async Task<Player> GetPlayer(string playerId)
        {
            return await _playerRepository.GetPlayerAsync(id: playerId);
        }

        private readonly IPlayerRepository _playerRepository;
    }
}