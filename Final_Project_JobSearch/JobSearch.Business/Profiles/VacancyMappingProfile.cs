using AutoMapper;
using JobSearch.Business.DTOs.VacancyDTOs;
using JobSearch.Core.Entities;

namespace JobSearch.Business.Profiles
{
    public class VacancyMappingProfile : Profile
    {
        public VacancyMappingProfile()
        {
            CreateMap<VacancyCreateDTO, Vacancy>();
            CreateMap<VacancyUpdateDTO, Vacancy>().ReverseMap();
            CreateMap<VacancyInfoDTO, Vacancy>().ReverseMap();
            CreateMap<VacancyShortInfoDTO, Vacancy>().ReverseMap();
            CreateMap<Vacancy, VacancyListItemDTO>()
                  .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Phone.Number))
                  .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email.EmailAddress))
                  .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category.Name))
                  .ForMember(dest => dest.MaxSalary, opt => opt.MapFrom(src => src.MaxSalary.Amount))
                  .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender.Title))
                  .ForMember(dest => dest.EducationId, opt => opt.MapFrom(src => src.Education.Degree))
                  .ForMember(dest => dest.ExperienceYear, opt => opt.MapFrom(src => src.ExperienceYear.ExpYear))
                  .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.City.Name))
                  .ForMember(dest => dest.TypeOfVacancy, opt => opt.MapFrom(src => src.TypeOfVacancy.Title))
                  .ForMember(dest => dest.WorkType, opt => opt.MapFrom(src => src.WorkType.Title))
                  .ForMember(dest => dest.CompanyName, opt => opt.MapFrom(src => src.Company.Name))
                  .ForMember(dest => dest.CompanyAbout, opt => opt.MapFrom(src => src.Company.About))
                  .ForMember(dest => dest.CompanyId, opt => opt.MapFrom(src => src.Company.Id));
                  //.ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Company.UserId));
        }
    }
}
