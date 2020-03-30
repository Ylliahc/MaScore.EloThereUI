using AutoMapper;

namespace MaScore.EloThereUI.Infrastructure.MappingProfiles
{
    /// <summary>
    /// Mapping profile for player
    /// </summary>
    public class PlayerMappingProfile : Profile
    {
        public PlayerMappingProfile()
        {
            CreateMap<Entities.PlayerBase,Domain.Entities.Player>()
                .ForMember( dest => dest .GameTypes, opt => opt.Ignore()).ReverseMap();
        }
    }
}