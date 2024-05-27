using JobSearch.Business.DTOs.CityDTOs;

namespace JobSearch.Business.Services.Interfaces
{
    public interface ICityService
    {
        public IEnumerable<CityListItemDTO> GetAll();
        public Task CreateAsync(CityCreateDTO dto);
        Task Delete(int id);
        Task Update(int id, CityUpdateDTO dto);
    }
}
