using MaScore.EloThereUI.Application.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace WebApp
{
    public class TestBase : ComponentBase
    {
        private readonly GameTypeService _gameTypeService;
        public WebApp.ViewModels.TestForm _TestForm = new ViewModels.TestForm();

        /*public TestBase(MaScore.EloThereUI.Application.Services.GameTypeService gameTypeService)
        {
            _gameTypeService = gameTypeService;
        }*/

        public async Task HandleValidSubmit()
        {
            Console.WriteLine(_TestForm.GameTypeId);
            await _gameTypeService.Get(_TestForm.GameTypeId);
        }
    }
}