using AutoMapper;
using JobSearch.Business.DTOs.EducationDTOs;
using JobSearch.Business.DTOs.PhoneDTOs;
using JobSearch.Business.DTOs.SalaryDTOs;
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
    public class SalaryService : ISalaryService
    {
        ISalaryRepository _repo { get; }
        IMapper _mapper { get; }

        public SalaryService(ISalaryRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task CreateAsync(SalaryCreateDTO dto)
        {
            if (await _repo.IsExistAsync(r => r.Amount.ToLower() == dto.Amount.ToLower()))
                throw new AlreadyExistException<Salary>();
            await _repo.CreateAsync(_mapper.Map<Salary>(dto));
            await _repo.SaveAsync();

        }

        public IEnumerable<SalaryListItemDTO> GetAll()
        {
            var data = _repo.GetAll();
            return _mapper.Map<IEnumerable<SalaryListItemDTO>>(data);
        }
        public async Task Update(int id, SalaryUpdateDTO dto)
        {
            var data = await _repo.GetByIdAsync(id, false);
            if (data == null) throw new NotFoundException<Salary>();
            if (await _repo.IsExistAsync(r => r.Amount.ToLower() == dto.Amount.ToLower()))
                throw new AlreadyExistException<Salary>();
            data = _mapper.Map(dto, data);
            await _repo.SaveAsync();
        }
        public async Task Delete(int id)
        {
            var data = await _repo.GetByIdAsync(id, false);
            if (data == null) throw new NotFoundException<Salary>();
            _repo.Remove(data);
            await _repo.SaveAsync();
        }
    }
}

