using AutoMapper;
using JobSearch.Business.DTOs.EducationDTOs;
using JobSearch.Business.DTOs.ExperianceYearDTOs;
using JobSearch.Business.Exceptions.CommonExceptions;
using JobSearch.Business.Repositories.Interfaces;
using JobSearch.Business.Services.Interfaces;
using JobSearch.Core.Entities;

namespace JobSearch.Business.Services.Implements
{
    public class ExperienceYearService : IExperienceYearService
    {
        IExperienceYearRepository _repo { get; }
        IMapper _mapper { get; }

        public ExperienceYearService(IExperienceYearRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task CreateAsync(ExperienceYearCreateDTO dto)
        {  
            if (await _repo.IsExistAsync(r => r.ExpYear.ToLower() == dto.ExpYear.ToLower()))
                throw new AlreadyExistException<ExperienceYear>();

            await _repo.CreateAsync(_mapper.Map<ExperienceYear>(dto));
            await _repo.SaveAsync();
        }

        public IEnumerable<ExperienceYearListItemDTO> GetAll()
        {
            var data = _repo.GetAll();
            return _mapper.Map<IEnumerable<ExperienceYearListItemDTO>>(data);
        }
        public async Task Update(int id, ExperienceYearUpdateDTO dto)
        {
            var data = await _repo.GetByIdAsync(id, false);
            if (data == null) throw new NotFoundException<ExperienceYear>();
            if (await _repo.IsExistAsync(r => r.ExpYear.ToLower() == dto.ExpYear.ToLower()))
                throw new AlreadyExistException<ExperienceYear>();
            data = _mapper.Map(dto, data);
            await _repo.SaveAsync();
        }
        public async Task Delete(int id)
        {
            var data = await _repo.GetByIdAsync(id, false);
            if (data == null) throw new NotFoundException<ExperienceYear>();
            _repo.Remove(data);
            await _repo.SaveAsync();
        }
    }
}
