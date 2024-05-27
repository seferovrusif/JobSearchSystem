using AutoMapper;
using JobSearch.Business.DTOs.SalaryDTOs;
using JobSearch.Business.DTOs.SocialMediaDTOs;
using JobSearch.Business.Exceptions.CommonExceptions;
using JobSearch.Business.Repositories.Interfaces;
using JobSearch.Business.Services.Interfaces;
using JobSearch.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearch.Business.Services.Implements
{
    public class SocialMediaService : ISocialMediaService
    {
        ISocialMediaRepository _repo { get; }
        IMapper _mapper { get; }

        public SocialMediaService(ISocialMediaRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task CreateAsync(SocialMediaCreateDTO dto)
        {
            if (await _repo.IsExistAsync(r => r.Title.ToLower() == dto.Title.ToLower()) || await _repo.IsExistAsync(r => r.MainLink.ToLower() == dto.MainLink.ToLower()))
                throw new AlreadyExistException<SocialMedia>();

            await _repo.CreateAsync(_mapper.Map<SocialMedia>(dto));
            await _repo.SaveAsync();

        }

        public IEnumerable<SocialMediaListItemDTO> GetAll()
        {
            var data = _repo.GetAll();
            return _mapper.Map<IEnumerable<SocialMediaListItemDTO>>(data);
        }
    }
}
