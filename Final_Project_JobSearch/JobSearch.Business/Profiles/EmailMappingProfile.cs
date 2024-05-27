using AutoMapper;
using JobSearch.Business.DTOs.EmailDTOs;
using JobSearch.Core.Entities;

namespace JobSearch.Business.Profiles
{
    public class EmailMappingProfile : Profile
    {
        public EmailMappingProfile()
        {
            CreateMap<EmailCreateDTO, Email>();
            CreateMap<Email, EmailListItemDTO>();
        }
    }
}
