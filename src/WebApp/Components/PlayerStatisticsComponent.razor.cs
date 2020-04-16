using Microsoft.AspNetCore.Components;

namespace WebApp.Components
{
    public class PlayerStatisticsComponentBase : ComponentBase
    {
        [Parameter]
        public ViewModels.PlayerStatisticsViewModel PlayerStatisticsViewModel { get;set;}

        [Parameter]
        public EventCallback<ViewModels.PlayerStatisticsViewModel> PlayerStatisticsViewModelChanged {get;set;}
    }
}