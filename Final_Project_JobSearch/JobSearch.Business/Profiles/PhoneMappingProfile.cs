using AutoMapper;
using JobSearch.Business.DTOs.PhoneDTOs;
using JobSearch.Core.Entities;

namespace JobSearch.Business.Profiles
{
    public class PhoneMappingProfile : Profile
    {
        public PhoneMappingProfile()
        {
            CreateMap<PhoneCreateDTO, Phone>();
            CreateMap< Phone , PhoneListItemDTO>();
        }
    }
}
