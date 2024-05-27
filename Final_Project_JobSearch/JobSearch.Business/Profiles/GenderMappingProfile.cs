using AutoMapper;
using JobSearch.Business.DTOs.GenderDTOs;
using JobSearch.Core.Entities;

namespace JobSearch.Business.Profiles
{
    public class GenderMappingProfile : Profile
    {
        public GenderMappingProfile()
        {
            CreateMap<GenderCreateDTO,Gender>();
            CreateMap<GenderUpdateDTO, Gender>();
            CreateMap<Gender,GenderListItemDTO>();
        }
    }
}

