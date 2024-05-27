using JobSearch.Business.DTOs.EmailDTOs;
using JobSearch.Business.DTOs.ExperianceYearDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearch.Business.Services.Interfaces
{
    public interface IExperienceYearService
    {
        public IEnumerable<ExperienceYearListItemDTO> GetAll();
        public Task CreateAsync(ExperienceYearCreateDTO dto);
        Task Delete(int id);
        Task Update(int id, ExperienceYearUpdateDTO dto);
    }
}
