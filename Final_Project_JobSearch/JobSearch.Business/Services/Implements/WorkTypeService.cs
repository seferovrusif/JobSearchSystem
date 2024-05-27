using AutoMapper;
using JobSearch.Business.DTOs.EducationDTOs;
using JobSearch.Business.DTOs.WorkTypeDTOs;
using JobSearch.Business.Exceptions.CommonExceptions;
using JobSearch.Business.Repositories.Interfaces;
using JobSearch.Business.Services.Interfaces;
using JobSearch.Core.Entities;

namespace JobSearch.Business.Services.Implements
{
    public class WorkTypeService : IWorkTypeService
    {
        IWorkTypeRepository _repo { get; }
        IMapper _mapper { get; }

        public WorkTypeService(IWorkTypeRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task CreateAsync(WorkTypeCreateDTO dto)
        {
            if (await _repo.IsExistAsync(r => r.Title.ToLower() == dto.Title.ToLower()))
                throw new AlreadyExistException<WorkType>();

            await _repo.CreateAsync(_mapper.Map< WorkType > (dto));
            await _repo.SaveAsync();
        }

        public IEnumerable<WorkTypeListItemDTO> GetAll()
        {
            var data = _repo.GetAll();
            return _mapper.Map<IEnumerable<WorkTypeListItemDTO>>(data);

        }
        public async Task Update(int id, WorkTypeUpdateDTO dto)
        {
            var data = await _repo.GetByIdAsync(id, false);
            if (data == null) throw new NotFoundException<WorkType>();
            if (await _repo.IsExistAsync(r => r.Title.ToLower() == dto.Title.ToLower()))
                throw new AlreadyExistException<WorkType>();
            data = _mapper.Map(dto, data);
            await _repo.SaveAsync();
        }
        public async Task Delete(int id)
        {
            var data = await _repo.GetByIdAsync(id, false);
            if (data == null) throw new NotFoundException<WorkType>();
            _repo.Remove(data);
            await _repo.SaveAsync();
        }
    }
}
