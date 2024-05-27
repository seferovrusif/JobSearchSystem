using AutoMapper;
using JobSearch.Business.DTOs.EducationDTOs;
using JobSearch.Business.DTOs.TypeOfVacancyDTOs;
using JobSearch.Business.Exceptions.CommonExceptions;
using JobSearch.Business.Repositories.Interfaces;
using JobSearch.Business.Services.Interfaces;
using JobSearch.Core.Entities;

namespace JobSearch.Business.Services.Implements
{
    public class TypeOfVacancyService : ITypeOfvacancyService

    {
        ITypeOfVacancyRepository _repo { get; }
        IMapper _mapper { get; }

        public TypeOfVacancyService(ITypeOfVacancyRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task CreateAsync(TypeOfVacancyCreateDTO dto)
        {
            if (await _repo.IsExistAsync(r => r.Title.ToLower() == dto.Title.ToLower()))
                throw new AlreadyExistException<TypeOfVacancy>();

            await _repo.CreateAsync(_mapper.Map<TypeOfVacancy>(dto));
            await _repo.SaveAsync();
        }

        public IEnumerable<TypeOfVacancyListItemDTO> GetAll()
        {
            var data = _repo.GetAll();
            return _mapper.Map<IEnumerable<TypeOfVacancyListItemDTO>>(data);

        }
        public async Task Update(int id, TypeOfVacancyUpdateDTO dto)
        {
            var data = await _repo.GetByIdAsync(id, false);
            if (data == null) throw new NotFoundException<TypeOfVacancy>();
            if (await _repo.IsExistAsync(r => r.Title.ToLower() == dto.Title.ToLower()))
                throw new AlreadyExistException<TypeOfVacancy>();
            data = _mapper.Map(dto, data);
            await _repo.SaveAsync();
        }
        public async Task Delete(int id)
        {
            var data = await _repo.GetByIdAsync(id, false);
            if (data == null) throw new NotFoundException<TypeOfVacancy>();
            _repo.Remove(data);
            await _repo.SaveAsync();
        }
    }
}
