using AutoMapper;
using JobSearch.Business.DTOs.CompanyDTOs;
using JobSearch.Business.Exceptions.CommonExceptions;
using JobSearch.Business.Repositories.Interfaces;
using JobSearch.Business.Services.Interfaces;
using JobSearch.Core.Entities;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace JobSearch.Business.Services.Implements
{
    public class CompanyService : ICompanyService
    {
        ICompanyRepository _repo { get; }
       
        IHttpContextAccessor _contextAccessor { get; }
        IMapper _mapper { get; }
        readonly string userId;

        public CompanyService(ICompanyRepository repo, IMapper mapper, IHttpContextAccessor contextAccessor)
        {
            _repo = repo;
            _mapper = mapper;
            _contextAccessor = contextAccessor;
            if (_contextAccessor.HttpContext.User.Claims.Any())
            {
                userId = _contextAccessor.HttpContext?.User?.Claims?.First(x => x.Type == ClaimTypes.NameIdentifier)?.Value ?? throw new NullReferenceException();
            }
           
        }


        public async Task CreateAsync(CompanyCreateDTO dto)
        {
            if (await _repo.IsExistAsync(r => r.Name.ToLower() == dto.Name.ToLower()))
                throw new AlreadyExistException<Company>();
            Company data = new Company
            {
                About = dto.About,
                Name = dto.Name,
                AuthorizedPerson = dto.AuthorizedPerson,
                Website = dto.Website,
                IsConfirmed = false
            };
            data.UserId = userId;
            
            await _repo.CreateAsync(data);

            await _repo.SaveAsync();
        }
        IEnumerable<CompanyListItemDTO> ICompanyService.GetAllActive()
        {
            var data = _repo.GetAll().Where(a => !a.IsDleted && a.IsConfirmed);
            return _mapper.Map<IEnumerable<CompanyListItemDTO>>(data);
        }
        public IEnumerable<CompanyListItemDTO> GetAll()
        {
            var data = _repo.GetAll();
            return _mapper.Map<IEnumerable<CompanyListItemDTO>>(data);
        }

        public async Task Delete(int id)
        {
            var data = await _repo.GetByIdAsync(id, false);
            if (data == null) throw new NotFoundException<Company>();
            if (data.UserId != userId) throw new Exception("User has no access");
            _repo.Remove(data);
            await _repo.SaveAsync();
        }

        public async Task SoftDelete(int id)
        {
            var data = await _repo.GetByIdAsync(id, false);
            if (data == null) throw new NotFoundException<Company>();
            if (data.UserId != userId) throw new Exception("User has no access");
            data.IsDleted = true;
            await _repo.SaveAsync();

        }

        public async Task ReverseSoftDelete(int id)
        {
            var data = await _repo.GetByIdAsync(id, false); 
            if (data == null) throw new NotFoundException<Company>();
            if (data.UserId != userId) throw new Exception("User has no access");
            data.IsDleted = false;
            await _repo.SaveAsync();

        }
        public async Task Confirmed(int id)
        {
            var data = await _repo.GetByIdAsync(id, false);
            if (data == null) throw new NotFoundException<Company>();
            data.IsConfirmed = true;
            await _repo.SaveAsync();

        }
        public async Task ReverseConfirmed(int id)
        {
            var data = await _repo.GetByIdAsync(id, false);
            if (data == null) throw new NotFoundException<Company>();
            data.IsConfirmed = false;
            await _repo.SaveAsync();

        }
        ///TODO: MApper le yazmaqi fikrles
        public async Task Update(int id, CompanyUpdateDTO dto)
        {
            var data = await _repo.GetByIdAsync(id, false);
            if (data == null) throw new NotFoundException<Company>();
            if (data.UserId != userId) throw new Exception("User has no access");
            if (await _repo.IsExistAsync(r => r.Name.ToLower() == dto.Name.ToLower()))
                throw new AlreadyExistException<Company>();

            data.About = dto.About;
            data.Name = dto.Name;
            data.AuthorizedPerson = dto.AuthorizedPerson;
            data.Website = dto.Website;
            data.IsConfirmed = false;
          
            await _repo.SaveAsync();
        }

        public async Task<CompanyInfoDTO> GetByIdAsync(int id)
        {
            var data = await _repo.GetByIdAsync(id, false);
            if (data == null) throw new NotFoundException<Company>("Company Not Found"); 
            return _mapper.Map<CompanyInfoDTO>(data);
        }

     
    }
}
