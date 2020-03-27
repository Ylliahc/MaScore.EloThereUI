using AutoMapper;

namespace MaScore.EloThereUI.Infrastructure.MappingProfiles
{
    public class PlayerMappingProfile : Profile
    {
        public PlayerMappingProfile()
        {
            CreateMap<Entities.PlayerBase,Domain.Entities.Player>()
                .ForMember( dest => dest .GameTypes, opt => opt.Ignore()).ReverseMap();
        }
    }
}