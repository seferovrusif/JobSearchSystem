    using JobSearch.Business.DTOs.CompanyDTOs;

namespace JobSearch.Business.Services.Interfaces
{
    public interface ICompanyService
    {
        public IEnumerable<CompanyListItemDTO> GetAll();
        public IEnumerable<CompanyListItemDTO> GetAllActive();
        public Task CreateAsync(CompanyCreateDTO dto);
        Task Delete(int id);
        Task SoftDelete(int id);
        Task ReverseSoftDelete(int id);
        Task Confirmed(int id);
        Task ReverseConfirmed(int id);
        Task Update(int id, CompanyUpdateDTO dto);
        ///TODOD:Get by id deki dtolari detail dto ile deyis
        public Task<CompanyInfoDTO> GetByIdAsync(int id);
    }


}
