using JobSearch.Business.DTOs.EducationDTOs;

namespace JobSearch.Business.Services.Interfaces
{
    public interface IEducationService
    {     
        public IEnumerable<EducationListItemDTO> GetAll();
        public Task CreateAsync(EducationCreateDTO dto);
        Task Delete(int id);
        Task Update(int id, EducationUpdateDTO dto);
    }
}
