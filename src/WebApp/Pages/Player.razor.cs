using System.Threading.Tasks;
using MaScore.EloThereUI.Application.Services;
using Microsoft.AspNetCore.Components;

namespace WebApp
{
    public class PlayerComponentBase : ComponentBase
    {
        public string PlayerId { get; set; }


        [Inject]
        public PlayerService PlayerService { get; set; }

        public ViewModels.PlayerGeneralInformationViewModel PlayerGeneralInformationViewModel = new ViewModels.PlayerGeneralInformationViewModel();

        public async Task GetPlayer()
        {
            var player = await PlayerService.GetPlayer(PlayerId);

            if(PlayerGeneralInformationViewModel == null)
                PlayerGeneralInformationViewModel = new ViewModels.PlayerGeneralInformationViewModel();

            PlayerGeneralInformationViewModel.FirstName = player.FirstName;
            PlayerGeneralInformationViewModel.LastName = player.LastName;
        }
    }
}