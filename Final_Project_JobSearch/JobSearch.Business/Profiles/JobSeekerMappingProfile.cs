using AutoMapper;
using JobSearch.Business.DTOs.JobSeekerDTOs;
using JobSearch.Core.Entities;

namespace JobSearch.Business.Profiles
{
    public class JobSeekerMappingProfile : Profile
    {
        public JobSeekerMappingProfile()
        {
            CreateMap<JobSeekerCreateDTO, JobSeeker>();
            CreateMap<JobSeekerUpdateDTO, JobSeeker>().ReverseMap();
            CreateMap<JobSeekerInfoDTO, JobSeeker>().ReverseMap();
            CreateMap<JobSeeker, JobSeekerListItemDTO>()
                  .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Phone.Number))
                  .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email.EmailAddress))
                  .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category.Name))
                  .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender.Title))
                  .ForMember(dest => dest.EducationId, opt => opt.MapFrom(src => src.Education.Degree))
                  .ForMember(dest => dest.ExperienceYear, opt => opt.MapFrom(src => src.ExperienceYear.ExpYear))
                  .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.City.Name));
        }
    }
}
