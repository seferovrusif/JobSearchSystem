using AutoMapper;
using JobSearch.Business.DTOs.SMCompanyDTOs;
using JobSearch.Core.Entities;

namespace JobSearch.Business.Profiles
{
    public class SocialMediaCompanyMappingProfile : Profile
    {
        public SocialMediaCompanyMappingProfile()
        {
            CreateMap<SMCompanyCreateDTO, SocialMediaCompany>();
            CreateMap<SocialMediaCompany, SMCompanyListItemDTO>()
                  .ForMember(dest => dest.SocialMediaId, opt => opt.MapFrom(src => src.SocialMedia.MainLink))
                  .ForMember(dest => dest.CompanyId, opt => opt.MapFrom(src => src.Company.Name));
        }
    }
}
