using JobSearch.Business.DTOs.GenderDTOs;

namespace JobSearch.Business.Services.Interfaces
{
    public interface IGenderService
    {
        public IEnumerable<GenderListItemDTO> GetAll();
        Task Delete(int id);
        public Task CreateAsync(GenderCreateDTO dto);
        Task Update(int id, GenderUpdateDTO dto);
    }
}
