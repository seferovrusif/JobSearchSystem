using AutoMapper;
using JobSearch.Business.DTOs.PhoneDTOs;
using JobSearch.Business.Exceptions.CommonExceptions;
using JobSearch.Business.Profiles;
using JobSearch.Business.Repositories.Interfaces;
using JobSearch.Business.Services.Interfaces;
using JobSearch.Core.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace JobSearch.Business.Services.Implements
{
    public class PhoneService : IPhoneService
    {
        IPhoneRepository _repo { get; }
        IMapper _mapper { get; }

        public PhoneService(IPhoneRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task CreateAsync(PhoneCreateDTO dto)
        {
            if (await _repo.IsExistAsync(r => r.Number.ToLower() == dto.Number.ToLower()))
                throw new AlreadyExistException<Phone>();
            await _repo.CreateAsync(_mapper.Map<Phone>(dto));
            await _repo.SaveAsync();

        }

        public  IEnumerable<PhoneListItemDTO> GetAll()
        {
            var data=  _repo.GetAll();
            return _mapper.Map< IEnumerable<PhoneListItemDTO>>(data);
        }
    }
}
