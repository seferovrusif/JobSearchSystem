using JobSearch.Business.DTOs.JobSeekerDTOs;

namespace JobSearch.Business.Services.Interfaces
{
    public interface IJobSeekerService
    {
        public IEnumerable<JobSeekerListItemDTO> GetAll();
        public IEnumerable<JobSeekerListItemDTO> GetAllActive();
        public Task CreateAsync(JobSeekerCreateDTO dto);
        Task Delete(int id);
        Task SoftDelete(int id);
        Task ReverseSoftDelete(int id);
        Task Confirmed(int id);
        Task ReverseConfirmed(int id);
        Task ReversePremium(int id);
        Task MakePremium(int id);
        Task Update(int id, JobSeekerUpdateDTO dto);
        public Task<JobSeekerInfoDTO> GetByIdAsync(int id);
    }
}
