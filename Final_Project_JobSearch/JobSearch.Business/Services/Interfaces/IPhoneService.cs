using JobSearch.Business.DTOs.PhoneDTOs;

namespace JobSearch.Business.Services.Interfaces
{
    public interface IPhoneService
    {
        public IEnumerable<PhoneListItemDTO> GetAll();
        public Task CreateAsync(PhoneCreateDTO dto);
    }
}
