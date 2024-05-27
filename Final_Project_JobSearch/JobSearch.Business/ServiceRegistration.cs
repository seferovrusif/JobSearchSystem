using FluentValidation.AspNetCore;
using JobSearch.Business.DTOs.AuthDTOs;
using JobSearch.Business.ExternalServices.Implements;
using JobSearch.Business.ExternalServices.Interfaces;
using JobSearch.Business.Profiles;
using JobSearch.Business.Repositories.Implements;
using JobSearch.Business.Repositories.Interfaces;
using JobSearch.Business.Services.Implements;
using JobSearch.Business.Services.Interfaces;
using JobSearch.Core.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace JobSearch.Business
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<IPhoneRepository, PhoneRepository>();
            services.AddScoped<IEmailRepository, EmailRepository>();
            services.AddScoped<IGenderRepository, GenderRepository>();
            services.AddScoped<IEducationRepository, EducationRepository>();
            services.AddScoped<IExperienceYearRepository, ExperienceYearRepository>();
            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<ISalaryRepository, SalaryRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ISocialMediaRepository, SocialMediaRepository>();
            services.AddScoped<ITypeOfVacancyRepository, TypeOfVacancyRepository>();
            services.AddScoped<IWorkTypeRepository, WorkTypeRepository>();
            services.AddScoped<IVacancyRepository, VacancyRepository>();
            services.AddScoped<IJobSeekerRepository, JobSeekerRepository>();
            services.AddScoped<ISMJobSeekerRepository, SMJobSeekerRepository>();
            services.AddScoped<ISMCompanyRepository, SMCompanyRepository>();
            return services;
        }
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IAppService, AppService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IPhoneService, PhoneService>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<IGenderService, GenderService>();
            services.AddScoped<IEducationService, EducationService>();
            services.AddScoped<IExperienceYearService, ExperienceYearService>();
            services.AddScoped<ICityService, CityService>();
            services.AddScoped<ISalaryService, SalaryService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ISocialMediaService, SocialMediaService>();
            services.AddScoped<ITypeOfvacancyService, TypeOfVacancyService>();
            services.AddScoped<IWorkTypeService, WorkTypeService>();
            services.AddScoped<IVacancyService, VacancyService>();
            services.AddScoped<IJobSeekerService, JobSeekerService>();
            services.AddScoped<ISMJobSeekerService, SMJobSeekerService>();
            services.AddScoped<ISMCompanyService, SMCompanyService>();
            return services;
        }
        
        public static IServiceCollection AddBusinessLayer(this IServiceCollection services)
        {
            services.AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<RegisterDTOValidator>());
            services.AddAutoMapper(typeof(AppUserMappingProfile).Assembly);
            return services;
        }
    }
}
