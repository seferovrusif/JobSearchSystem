using AutoMapper;
using JobSearch.Business.DTOs.SMCompanyDTOs;
using JobSearch.Business.Exceptions.CommonExceptions;
using JobSearch.Business.Repositories.Interfaces;
using JobSearch.Business.Services.Interfaces;
using JobSearch.Core.Entities;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace JobSearch.Business.Services.Implements
{
    public class SMCompanyService : ISMCompanyService
    {
        ISMCompanyRepository _repo { get; }
        ICompanyRepository _companyRepo { get; }
        IHttpContextAccessor _contextAccessor { get; }
        IMapper _mapper { get; }
        readonly string userId;

        public SMCompanyService(ISMCompanyRepository repo, IMapper mapper, ICompanyRepository companyRepo, IHttpContextAccessor contextAccessor)
        {
            _repo = repo;
            _mapper = mapper;
            _companyRepo = companyRepo;
            _contextAccessor = contextAccessor;
            if (_contextAccessor.HttpContext.User.Claims.Any())
            {
                userId = _contextAccessor.HttpContext?.User?.Claims?.First(x => x.Type == ClaimTypes.NameIdentifier)?.Value ?? throw new NullReferenceException();
            }
            _contextAccessor = contextAccessor;
        }
        public async Task CreateAsync(SMCompanyCreateDTO dto)
        {
            await _repo.CreateAsync(_mapper.Map<SocialMediaCompany>(dto));
            await _repo.SaveAsync();

        }

        public IEnumerable<SMCompanyListItemDTO> GetAll()
        {
            var data = _repo.GetAll();
            return _mapper.Map<IEnumerable<SMCompanyListItemDTO>>(data);
        }
        public async Task AddSM(SMCompanyCreateDTO dto)
        {
            Company company = await _companyRepo.GetByIdAsync(dto.CompanyId, false);
            if (company == null) throw new NotFoundException<Company>();
            if (company.UserId != userId) throw new Exception("User has no access");
            await _repo.AddSM(_mapper.Map<SocialMediaCompany>(dto));

            await _repo.SaveAsync();
        }
    }

}

