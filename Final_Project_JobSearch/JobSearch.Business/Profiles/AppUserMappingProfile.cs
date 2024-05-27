using AutoMapper;
using JobSearch.Business.DTOs.AuthDTOs;
using JobSearch.Core.Entities;

namespace JobSearch.Business.Profiles
{
    public class AppUserMappingProfile : Profile
    {
        public AppUserMappingProfile()
        {
            CreateMap<RegisterDTO, AppUser>();
        }
    }
}
