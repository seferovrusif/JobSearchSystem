using AutoMapper;
using JobSearch.Business.DTOs.JobSeekerDTOs;
using JobSearch.Business.DTOs.VacancyDTOs;
using JobSearch.Business.Exceptions.CommonExceptions;
using JobSearch.Business.Repositories.Interfaces;
using JobSearch.Business.Services.Interfaces;
using JobSearch.Core.Entities;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace JobSearch.Business.Services.Implements
{
    public class VacancyService : IVacancyService
    {
        IVacancyRepository _repo { get; }
        IMapper _mapper { get; }
        IPhoneRepository _phoneRepo { get; }
        ICompanyRepository _companyRepo { get; }
        IEmailRepository _emailRepo { get; }
        IHttpContextAccessor _contextAccessor { get; }
        readonly string userId;

        public VacancyService(IVacancyRepository repo, IMapper mapper, IHttpContextAccessor contextAccessor, IPhoneRepository phoneRepo, IEmailRepository emailRepo, ICompanyRepository companyRepo)
        {
            _repo = repo;
            _mapper = mapper;
            _contextAccessor = contextAccessor;
            if (_contextAccessor.HttpContext.User.Claims.Any())
            {
                userId = _contextAccessor.HttpContext?.User?.Claims?.First(x => x.Type == ClaimTypes.NameIdentifier)?.Value ?? throw new NullReferenceException();
            }
            _phoneRepo = phoneRepo;
            _emailRepo = emailRepo;
            _companyRepo = companyRepo;
        }

        public async Task CreateAsync(VacancyCreateDTO dto)
        {
        
            Vacancy data = new Vacancy
            {
                CategoryId = dto.CategoryId,
                Position = dto.Position,
                MaxSalaryId = dto.MaxSalaryId,
                AboutWork = dto.AboutWork,
                Requirements = dto.Requirements,
                MaxYas = dto.MaxYas,
                MinYas = dto.MinYas,
                GenderId = dto.GenderId,
                EducationId = dto.EducationId,
                ExperienceYearId = dto.ExperienceYearId,
                CityId = dto.CityId,
                TypeOfVacancyId = dto.TypeOfVacancyId,
                WorkTypeId = dto.WorkTypeId,
                AuthorizedPerson = dto.AuthorizedPerson,
                DeadLine = dto.DeadLine,
                Website = dto.Website,

            };
            Company company = await _companyRepo.GetByIdAsync(dto.CompanyId, false);
            if (company == null) throw new NotFoundException<Company>();
            if (company.UserId != userId) throw new Exception("User has no access");
            data.CompanyId = company.Id;
            ///TODO:daha optimal ola bilerdi(ilk create edib exception tut ama unique lazmdi
            if (_emailRepo.GetIdFromEmail(dto.Email) == 0)
            {
                Email email = new Email { EmailAddress = dto.Email };
                await _emailRepo.CreateAsync(email);
                await _emailRepo.SaveAsync();
            }
            data.EmailId = _emailRepo.GetIdFromEmail(dto.Email);

            if (_phoneRepo.GetIdFromNumber(dto.Phone) == 0)
            {
                Phone phone = new Phone { Number = dto.Phone };
                await _phoneRepo.CreateAsync(phone);
                await _phoneRepo.SaveAsync();
            }
            data.PhoneId = _phoneRepo.GetIdFromNumber(dto.Phone);
            data.LastActiveTime=DateTime.Now;
            await _repo.CreateAsync(_mapper.Map<Vacancy>(data));
            await _repo.SaveAsync();
        }

        public IEnumerable<VacancyListItemDTO> GetAllActive()
        {
            var data = _repo.GetAll(true, "Phone", "Email", "Category", "MaxSalary", "Gender", "Education", "ExperienceYear", "City", "TypeOfVacancy", "WorkType","Company")
                .Where(a => a.LastActiveTime > DateTime.Now &&
                            a.DeadLine > DateTime.Now  &&
                            !a.IsDleted)
                            .OrderByDescending(q=>q.IsPremium);
            return _mapper.Map<IEnumerable<VacancyListItemDTO>>(data);

        }
        public IEnumerable<VacancyListItemDTO> GetAll()
        {
            var data = _repo.GetAll(true, "Phone", "Email", "Category", "MaxSalary", "Gender", "Education", "ExperienceYear", "City", "TypeOfVacancy", "WorkType","Company");
            return _mapper.Map<IEnumerable<VacancyListItemDTO>>(data);

        }
        public async Task Delete(int id)
        {
            var data = await _repo.GetByIdAsync(id, false);
            if (data == null) throw new NotFoundException<Vacancy>();
            //if (data.UserId != userId) throw new Exception("User has no access");
            _repo.Remove(data);
            await _repo.SaveAsync();
        }

        public async Task SoftDelete(int id)
        {
            var data = await _repo.GetByIdAsync(id, false);
            if (data == null) throw new NotFoundException<Vacancy>();
            //if (data.UserId != userId) throw new Exception("User has no access");
            data.IsDleted = true;
            await _repo.SaveAsync();

        }

        public async Task ReverseSoftDelete(int id)
        {
            var data = await _repo.GetByIdAsync(id, false);
            if (data == null) throw new NotFoundException<Vacancy>();
            //if (data.UserId != userId) throw new Exception("User has no access");
            data.IsDleted = false;
            await _repo.SaveAsync();

        }
        public async Task Confirmed(int id)
        {
            var data = await _repo.GetByIdAsync(id, false);
            if (data == null) throw new NotFoundException<Vacancy>();
            data.IsConfirmed = true;
            data.LastActiveTime = DateTime.UtcNow.AddDays(30);
            await _repo.SaveAsync();

        }
        public async Task ReverseConfirmed(int id)
        {
            var data = await _repo.GetByIdAsync(id, false);
            if (data == null) throw new NotFoundException<Vacancy>();
            data.IsConfirmed = false;
            data.LastActiveTime = DateTime.UtcNow.AddDays(30);
            await _repo.SaveAsync();

        }
        public async Task MakePremium(int id)
        {
            var data = await _repo.GetByIdAsync(id, false);
            if (data == null) throw new NotFoundException<Vacancy>();
            data.IsPremium = true;
            await _repo.SaveAsync();

        }
        public async Task ReversePremium(int id)
        {
            var data = await _repo.GetByIdAsync(id, false);
            if (data == null) throw new NotFoundException<Vacancy>();
            data.IsPremium = false;
            await _repo.SaveAsync();

        }

        public async Task Update(int id, VacancyUpdateDTO dto)
        {
            var data = await _repo.GetByIdAsync(id, false);
            if (data == null) throw new NotFoundException<Vacancy>();
            Company company = await _companyRepo.GetByIdAsync(dto.CompanyId, false);
            if (company == null) throw new NotFoundException<Company>();
            if (company.UserId != userId) throw new Exception("User has no access");
            //if (data.UserId != userId) throw new Exception("User has no access");

            data.CategoryId = dto.CategoryId;
            data.Position = dto.Position;
            data.MaxSalaryId = dto.MaxSalaryId;
            data.AboutWork = dto.AboutWork;
            data.Requirements = dto.Requirements;
            data.MaxYas = dto.MaxYas;
            data.MinYas = dto.MinYas;
            data.GenderId = dto.GenderId;
            data.EducationId = dto.EducationId;
            data.ExperienceYearId = dto.ExperienceYearId;
            data.CityId = dto.CityId;
            data.TypeOfVacancyId = dto.TypeOfVacancyId;
            data.WorkTypeId = dto.WorkTypeId;
            data.AuthorizedPerson = dto.AuthorizedPerson;
            data.DeadLine = dto.DeadLine;
            data.Website = dto.Website;

            data.IsConfirmed=false;
            if (_emailRepo.GetIdFromEmail(dto.Email) == 0)
            {
                Email email = new Email { EmailAddress = dto.Email };
                await _emailRepo.CreateAsync(email);
                await _emailRepo.SaveAsync();
            }
            data.EmailId = _emailRepo.GetIdFromEmail(dto.Email);

            if (_phoneRepo.GetIdFromNumber(dto.Phone) == 0)
            {
                Phone phone = new Phone { Number = dto.Phone };
                await _phoneRepo.CreateAsync(phone);
                await _phoneRepo.SaveAsync();
            }
            data.PhoneId = _phoneRepo.GetIdFromNumber(dto.Phone);
            await _repo.SaveAsync();
        }

        public async Task<VacancyInfoDTO> GetByIdAsync(int id)
        {
            var data = await _repo.GetByIdAsync(id, true);
            if (data == null) throw new NotFoundException<Vacancy>("Vacancy Not Found");
            return _mapper.Map<VacancyInfoDTO>(data);
        }
        public async Task<VacancyShortInfoDTO> GetByIdShortAsync(int id)
        {
            var data = await _repo.GetByIdAsync(id, false);
            if (data == null) throw new NotFoundException<Vacancy>("Vacancy Not Found");
            return _mapper.Map<VacancyShortInfoDTO>(data);
        }

    }
}

