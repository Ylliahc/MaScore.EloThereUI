using AutoMapper;

namespace MaScore.EloThereUI.Infrastructure.MappingProfiles
{
    /// <summary>
    /// Mapping profile for scores
    /// </summary>
    public class ScoreMappingProfile : Profile
    {
        public ScoreMappingProfile()
        {
            CreateMap<Entities.Score, Domain.Entities.Score>();
        }
    }
}