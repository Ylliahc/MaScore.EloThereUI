using AutoMapper;

namespace WebApp.MappingProfiles
{
    public class PlayerStatisticsMappingProfile : Profile
    {
        public PlayerStatisticsMappingProfile()
        {
            CreateMap<MaScore.EloThereUI.Domain.Entities.PlayerStatistics
                        ,WebApp.ViewModels.PlayerStatisticsViewModel>();
        }
    }
}