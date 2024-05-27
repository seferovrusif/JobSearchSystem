using AutoMapper;
using JobSearch.Business.DTOs.EducationDTOs;
using JobSearch.Core.Entities;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace JobSearch.Business.Profiles
{
    public class EducationMappingProfile : Profile
    {
        public EducationMappingProfile()
        {
            
            CreateMap<EducationCreateDTO, Education>();
            CreateMap<EducationUpdateDTO, Education>();
            CreateMap<Education, EducationListItemDTO>();
        }
    }
}
