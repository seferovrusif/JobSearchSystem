using JobSearch.Business.DTOs.WorkTypeDTOs;

namespace JobSearch.Business.Services.Interfaces
{
    public interface IWorkTypeService
    {
        public IEnumerable<WorkTypeListItemDTO> GetAll();
        public Task CreateAsync(WorkTypeCreateDTO dto);
        Task Delete(int id);
        Task Update(int id, WorkTypeUpdateDTO dto);
    }
}
