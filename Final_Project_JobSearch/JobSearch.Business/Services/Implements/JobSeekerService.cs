using AutoMapper;
using JobSearch.Business.DTOs.JobSeekerDTOs;
using JobSearch.Business.Exceptions.CommonExceptions;
using JobSearch.Business.Repositories.Interfaces;
using JobSearch.Business.Services.Interfaces;
using JobSearch.Core.Entities;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace JobSearch.Business.Services.Implements
{
    public class JobSeekerService : IJobSeekerService
    {
        IJobSeekerRepository _repo { get; }
        IMapper _mapper { get; }
        IPhoneRepository _phoneRepo { get; }
        IEmailRepository _emailRepo { get; }
        readonly string userId;
        IHttpContextAccessor _contextAccessor { get; }

        public JobSeekerService(IJobSeekerRepository repo, IMapper mapper, IHttpContextAccessor contextAccessor, IPhoneRepository phoneRepo, IEmailRepository emailRepo)
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
        }

        public async Task CreateAsync(JobSeekerCreateDTO dto)
        {
       
            JobSeeker data = new JobSeeker
            {
                Name=dto.Name,
                Surname=dto.Surname,
                FatherName=dto.FatherName,
                ImageUrl=dto.ImageUrl,
                CVImgUrl=dto.CVImgUrl,
                CategoryId = dto.CategoryId,
                GenderId = dto.GenderId,
                EducationId = dto.EducationId,
                EducationDetail=dto.EducationDetail,
                ExperienceYearId = dto.ExperienceYearId,
                ExperienceDetail=dto.ExperienceDetail,
                Position = dto.Position,
                CityId = dto.CityId,
                Skills = dto.Skills,
                LanguageSkills=dto.LanguageSkills,
                AdditionalInformation  =dto.AdditionalInformation,
                BirthDate= dto.BirthDate,
                LastActiveTime=DateTime.Now
            };
            data.UserId = userId;
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
            await _repo.CreateAsync(_mapper.Map<JobSeeker>(data));
            await _repo.SaveAsync();
        }
        public IEnumerable<JobSeekerListItemDTO> GetAllActive()
        {
            var data = _repo.GetAll(true, "Phone", "Email", "Category",  "Gender", "Education", "ExperienceYear", "City")
                .Where(a=>!a.IsDleted && a.IsConfirmed && a.IsDleted == false && a.LastActiveTime>DateTime.Now)
                .OrderByDescending(q=>q.IsPremium);
            return _mapper.Map<IEnumerable<JobSeekerListItemDTO>>(data);

        }

        public IEnumerable<JobSeekerListItemDTO> GetAll()
        {
            var data = _repo.GetAll(true, "Phone", "Email", "Category", "Gender", "Education", "ExperienceYear", "City");
            return _mapper.Map<IEnumerable<JobSeekerListItemDTO>>(data);

        }
        public async Task Delete(int id)
        {
            var data = await _repo.GetByIdAsync(id, false);
            if (data == null) throw new NotFoundException<JobSeeker>();
            if (data.UserId != userId) throw new Exception("User has no access");
            _repo.Remove(data);
            await _repo.SaveAsync();
        }

        public async Task SoftDelete(int id)
        {
            var data = await _repo.GetByIdAsync(id, false);
            if (data == null) throw new NotFoundException<JobSeeker>();
            if (data.UserId != userId) throw new Exception("User has no access");
            data.IsDleted = true;
            await _repo.SaveAsync();

        }

        public async Task ReverseSoftDelete(int id)
        {
            var data = await _repo.GetByIdAsync(id, false);
            if (data == null) throw new NotFoundException<JobSeeker>();
            if (data.UserId != userId) throw new Exception("User has no access");
            data.IsDleted = false;
            await _repo.SaveAsync();

        }
        public async Task Confirmed(int id)
        {
            var data = await _repo.GetByIdAsync(id, false);
            if (data == null) throw new NotFoundException<JobSeeker>();
            data.IsConfirmed = true;
            data.LastActiveTime = DateTime.Now.AddDays(30);
            await _repo.SaveAsync();

        }
        public async Task ReverseConfirmed(int id)
        {
            var data = await _repo.GetByIdAsync(id, false);
            if (data == null) throw new NotFoundException<JobSeeker>();
            data.IsConfirmed = false;
            data.LastActiveTime = DateTime.Now.AddDays(30);
            await _repo.SaveAsync();

        }
        public async Task MakePremium(int id)
        {
            var data = await _repo.GetByIdAsync(id, false);
            if (data == null) throw new NotFoundException<JobSeeker>();
            data.IsPremium = true;
            await _repo.SaveAsync();

        }
        public async Task ReversePremium(int id)
        {
            var data = await _repo.GetByIdAsync(id, false);
            if (data == null) throw new NotFoundException<JobSeeker>();
            data.IsPremium = false;
            await _repo.SaveAsync();

        }

        public async Task Update(int id, JobSeekerUpdateDTO dto)
        {
            var data = await _repo.GetByIdAsync(id, false);
            if (data == null) throw new NotFoundException<JobSeeker>();
            if (data.UserId != userId) throw new Exception("User has no access");

            data.Name = dto.Name;
            data.Surname = dto.Surname;
            data.FatherName = dto.FatherName;
            data.ImageUrl = dto.ImageUrl;
            data.CVImgUrl = dto.CVImgUrl;
            data.CategoryId = dto.CategoryId;
            data.GenderId = dto.GenderId;
            data.EducationId = dto.EducationId;
            data.EducationDetail = dto.EducationDetail;
            data.ExperienceYearId = dto.ExperienceYearId;
            data.ExperienceDetail = dto.ExperienceDetail;
            data.Position = dto.Position;
            data.CityId = dto.CityId;
            data.Skills = dto.Skills;
            data.LanguageSkills = dto.LanguageSkills;
            data.AdditionalInformation = dto.AdditionalInformation;
            data.BirthDate = dto.BirthDate;

            data.IsConfirmed = false;
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
       
        public async Task<JobSeekerInfoDTO> GetByIdAsync(int id)
        {
            var data = await _repo.GetByIdAsync(id, true);
            if (data == null) throw new NotFoundException<JobSeeker>("JobSeeker Not Found");
            return _mapper.Map<JobSeekerInfoDTO>(data);
        }
    }
}


