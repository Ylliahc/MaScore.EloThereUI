using Microsoft.AspNetCore.Components;

namespace WebApp.Components
{
    public class PlayerGeneralPartComponentBase: ComponentBase
    {
        [Parameter]
        public WebApp.ViewModels.PlayerGeneralInformationViewModel PlayerGeneralInformationViewModel { get; set; }
        
        [Parameter]
        public EventCallback<WebApp.ViewModels.PlayerGeneralInformationViewModel> PlayerGeneralInformationViewModelChanged { get; set; }

        public void Update(WebApp.ViewModels.PlayerGeneralInformationViewModel playerGeneralInformationViewModel)
        {
            PlayerGeneralInformationViewModel = playerGeneralInformationViewModel;
        }

        
    }
}