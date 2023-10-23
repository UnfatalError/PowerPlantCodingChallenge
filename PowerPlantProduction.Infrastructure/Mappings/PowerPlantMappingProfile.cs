using AutoMapper;
using PowerPlantProduction.Application.DTO;
using PowerPlantProduction.Domain.Entities;

namespace PowerPlantProduction.Infrastructure.Mappings
{
    public sealed class PowerPlantMappingProfile : Profile
    {
        public PowerPlantMappingProfile()
        {
            CreateMap<PowerPlantDto, PowerPlant>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.MinProduction, opt => opt.MapFrom(src => src.PMin))
                .ForMember(dest => dest.MaxProduction, opt => opt.MapFrom(src => src.PMax));
        }
    }
}