using MaScore.EloThereUI.Application.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace WebApp
{
    public class TestBase : ComponentBase
    {
        [Inject]
        private GameTypeService _gameTypeService {get;set;}
        public WebApp.ViewModels.TestForm _TestForm = new ViewModels.TestForm();

        public string GameTypeName {get;set;}

        public async Task HandleValidSubmit()
        {
            var gameType = await _gameTypeService.Get(_TestForm.GameTypeId);
            GameTypeName = gameType.Name;
        }
    }
}