using AutoMapper;

namespace MaScore.EloThereUI.Infrastructure.MappingProfiles
{
    public class ScoreMappingProfile : Profile
    {
        public ScoreMappingProfile()
        {
            CreateMap<Entities.Score, Domain.Entities.Score>();
        }
    }
}