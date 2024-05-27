using AutoMapper;
using JobSearch.Business.DTOs.SMJobSeekerDTOs;
using JobSearch.Core.Entities;

namespace JobSearch.Business.Profiles
{
    public class SocialMediaJobSeekerMappingProfile : Profile
    {
        public SocialMediaJobSeekerMappingProfile()
        {
            CreateMap<SMJobSeekerCreateDTO, SocialMediaJobSeeker>();
            CreateMap<SocialMediaJobSeeker, SMJobSeekerListItemDTO>()
                  .ForMember(dest => dest.SocialMediaId, opt => opt.MapFrom(src => src.SocialMedia.MainLink))
                  .ForMember(dest => dest.JobSeekerId, opt => opt.MapFrom(src => src.JobSeeker.Name)); ;
        }
    }
}
