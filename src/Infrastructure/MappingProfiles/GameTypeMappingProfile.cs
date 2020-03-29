using AutoMapper;

namespace MaScore.EloThereUI.Infrastructure.MappingProfiles
{
    /// <summary>
    /// Mapping profile for game types
    /// </summary>
    public class GameTypeMappingProfile : Profile
    {
        public GameTypeMappingProfile()
        {
            CreateMap<Entities.GameType, Domain.Entities.GameType>();
        }
    }
}