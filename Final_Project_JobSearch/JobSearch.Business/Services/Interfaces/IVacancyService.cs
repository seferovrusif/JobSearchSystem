using JobSearch.Business.DTOs.JobSeekerDTOs;
using JobSearch.Business.DTOs.VacancyDTOs;

namespace JobSearch.Business.Services.Interfaces
{
    public interface IVacancyService
    {
        public IEnumerable<VacancyListItemDTO> GetAll();
        public IEnumerable<VacancyListItemDTO> GetAllActive();
        public Task CreateAsync(VacancyCreateDTO dto);
        Task Delete(int id);
        Task SoftDelete(int id);
        Task ReverseSoftDelete(int id);
        Task ReverseConfirmed(int id); 
        Task Confirmed(int id); 
        Task ReversePremium(int id); 
        Task MakePremium(int id);
        Task Update(int id, VacancyUpdateDTO dto);
        public Task<VacancyInfoDTO> GetByIdAsync(int id);
        public Task<VacancyShortInfoDTO> GetByIdShortAsync(int id);
        
    }
}
