using AutoMapper;
using JobSearch.Business.DTOs.ExperianceYearDTOs;
using JobSearch.Core.Entities;

namespace JobSearch.Business.Profiles
{
    public class ExperienceYearMappingProfile : Profile
    {
        public ExperienceYearMappingProfile()
        {
            
            CreateMap<ExperienceYearCreateDTO, ExperienceYear>();
            CreateMap<ExperienceYearUpdateDTO, ExperienceYear>();
            CreateMap<ExperienceYear, ExperienceYearListItemDTO>();
        }
    }
}
