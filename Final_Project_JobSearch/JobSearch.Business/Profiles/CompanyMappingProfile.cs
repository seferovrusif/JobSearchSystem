using AutoMapper;
using JobSearch.Business.DTOs.CompanyDTOs;
using JobSearch.Core.Entities;

namespace JobSearch.Business.Profiles
{
    public class CompanyMappingProfile : Profile
    {
        public CompanyMappingProfile()
        {
            CreateMap<CompanyCreateDTO, Company>();
            CreateMap<CompanyUpdateDTO, Company>().ReverseMap();
            CreateMap<Company, CompanyInfoDTO>().ReverseMap();
            CreateMap<Company, CompanyListItemDTO>();
                 
        }
    }

}
    