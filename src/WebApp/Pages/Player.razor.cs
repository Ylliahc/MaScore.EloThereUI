using System.Threading.Tasks;
using AutoMapper;
using MaScore.EloThereUI.Application.Services;
using Microsoft.AspNetCore.Components;

namespace WebApp
{
    public class PlayerComponentBase : ComponentBase
    {
        public string PlayerId { get; set; }

        [Inject]
        public IMapper _mapper {get; private set;}

        [Inject]
        public PlayerService PlayerService { get; set; }

        [Inject]
        public StatisticsService StatisticsService {get;set;}

        public ViewModels.PlayerGeneralInformationViewModel PlayerGeneralInformationViewModel = new ViewModels.PlayerGeneralInformationViewModel();
        public ViewModels.PlayerStatisticsViewModel PlayerStatisticsViewModel = new ViewModels.PlayerStatisticsViewModel();

        public async Task GetPlayer()
        {
            if(string.IsNullOrWhiteSpace(PlayerId))
                return;
            var player = await PlayerService.GetPlayer(PlayerId);

            if(PlayerGeneralInformationViewModel == null)
                PlayerGeneralInformationViewModel = new ViewModels.PlayerGeneralInformationViewModel();

            PlayerGeneralInformationViewModel.FirstName = player.FirstName;
            PlayerGeneralInformationViewModel.LastName = player.LastName;
        }

        public async Task GetPlayerStatistics()
        {
            if(string.IsNullOrWhiteSpace(PlayerId))
                return;

            var statistics = await StatisticsService.GetPlayerStatisticsAsync(playerId: PlayerId);

            PlayerStatisticsViewModel = _mapper.Map<ViewModels.PlayerStatisticsViewModel>(statistics);
 
        }

        public async Task HandleClick()
        {
            await GetPlayer();
            await GetPlayerStatistics();
        }
    }
}