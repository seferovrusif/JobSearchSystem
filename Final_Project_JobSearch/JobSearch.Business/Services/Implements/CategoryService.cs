using AutoMapper;
using JobSearch.Business.DTOs.CategoryDTOs;
using JobSearch.Business.Exceptions.CommonExceptions;
using JobSearch.Business.Repositories.Interfaces;
using JobSearch.Business.Services.Interfaces;
using JobSearch.Core.Entities;

namespace JobSearch.Business.Services.Implements
{
    public class CategoryService : ICategoryService 
    {
        ICategoryRepository _repo { get; }
        IMapper _mapper { get; }

        public CategoryService(ICategoryRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task CreateAsync(CategoryCreateDTO dto)
        {
            if (await _repo.IsExistAsync(r => r.Name.ToLower() == dto.Name.ToLower()))
                throw new AlreadyExistException<Category>();
            if (dto.ParentId != null)
            {
                var data = await _repo.GetByIdAsync(dto.ParentId.Value, false);
                if (data == null) throw new NotFoundException<Category>("ParentId Not Found");

            }
            await _repo.CreateAsync(_mapper.Map<Category>(dto));
            await _repo.SaveAsync();
        }

        public IEnumerable<CategoryListItemDTO> GetAll()
        {
            var data = _repo.GetAll();
            return _mapper.Map<IEnumerable<CategoryListItemDTO>>(data);

        }
    }
}
