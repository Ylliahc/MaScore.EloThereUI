using Microsoft.AspNetCore.Components;

namespace WebApp.Components
{
    public class PlayerGeneralPartComponentBase: ComponentBase
    {
        [Parameter]
        public WebApp.ViewModels.PlayerGeneralInformationViewModel PlayerGeneralInformationViewModel { get; set; }
    }
}