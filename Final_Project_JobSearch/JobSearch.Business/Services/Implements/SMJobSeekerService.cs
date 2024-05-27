using AutoMapper;
using JobSearch.Business.DTOs.SMJobSeekerDTOs;
using JobSearch.Business.Exceptions.CommonExceptions;
using JobSearch.Business.Repositories.Interfaces;
using JobSearch.Business.Services.Interfaces;
using JobSearch.Core.Entities;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace JobSearch.Business.Services.Implements
{
    public class SMJobSeekerService : ISMJobSeekerService
    {
        ISMJobSeekerRepository _repo { get; }
        IJobSeekerRepository _sekerRepo { get; }
        ISocialMediaRepository _SMRepo { get; }
        IHttpContextAccessor _contextAccessor { get; }
        IMapper _mapper { get; }
        readonly string userId;
        public SMJobSeekerService(ISMJobSeekerRepository repo, IMapper mapper, IHttpContextAccessor contextAccessor, IJobSeekerRepository sekerRepo, ISocialMediaRepository sMRepo)
        {
            _repo = repo;
            _mapper = mapper;
            _contextAccessor = contextAccessor;
            if (_contextAccessor.HttpContext.User.Claims.Any())
            {
                userId = _contextAccessor.HttpContext?.User?.Claims?.First(x => x.Type == ClaimTypes.NameIdentifier)?.Value ?? throw new NullReferenceException();
            }
            _sekerRepo = sekerRepo;
            _SMRepo = sMRepo;
        }
        public async Task CreateAsync(SMJobSeekerCreateDTO dto)
        {
            //if (await _repo.IsExistAsync(r => r.Title.ToLower() == dto.Title.ToLower()) || await _repo.IsExistAsync(r => r.MainLink.ToLower() == dto.MainLink.ToLower()))
            //    throw new Exception("Already exist");
            await _repo.CreateAsync(_mapper.Map< SocialMediaJobSeeker>(dto));
            await _repo.SaveAsync();

        }

        public IEnumerable<SMJobSeekerListItemDTO> GetAll()
        {
            var data = _repo.GetAll();
            return _mapper.Map<IEnumerable<SMJobSeekerListItemDTO>>(data);
        }
    public async Task AddSM(SMJobSeekerCreateDTO dto)
        {
            SocialMedia sm = await _SMRepo.GetByIdAsync(dto.SocialMediaId, false);
            if (sm == null) throw new NotFoundException<SocialMedia>();
            JobSeeker seeker= await _sekerRepo.GetByIdAsync(dto.JobSeekerId, false);
            if (seeker == null) throw new NotFoundException<JobSeeker>();
            if (seeker.UserId != userId) throw new Exception("User has no access");
            await _repo.AddSM(_mapper.Map<SocialMediaJobSeeker>(dto));

        await _repo.SaveAsync();
    }
}


    }