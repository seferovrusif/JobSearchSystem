using JobSearch.Business.DTOs.TypeOfVacancyDTOs;

namespace JobSearch.Business.Services.Interfaces
{
    public interface ITypeOfvacancyService
    {
        public IEnumerable<TypeOfVacancyListItemDTO> GetAll();
        public Task CreateAsync(TypeOfVacancyCreateDTO dto);
        Task Update(int id, TypeOfVacancyUpdateDTO dto);
        Task Delete(int id);
    }
}
