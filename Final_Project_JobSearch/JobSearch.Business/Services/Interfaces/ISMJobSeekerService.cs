using JobSearch.Business.DTOs.SMCompanyDTOs;
using JobSearch.Business.DTOs.SMJobSeekerDTOs;

namespace JobSearch.Business.Services.Interfaces
{
    public interface ISMJobSeekerService
    {
        public IEnumerable<SMJobSeekerListItemDTO> GetAll();
        public Task CreateAsync(SMJobSeekerCreateDTO dto);
        public Task AddSM(SMJobSeekerCreateDTO dto);

    }
}
