using JobSearch.Business.DTOs.SMCompanyDTOs;

namespace JobSearch.Business.Services.Interfaces
{
    public interface ISMCompanyService
    {
        public IEnumerable<SMCompanyListItemDTO> GetAll();
        public Task CreateAsync(SMCompanyCreateDTO dto);
        public Task AddSM(SMCompanyCreateDTO dto);

    }
}
