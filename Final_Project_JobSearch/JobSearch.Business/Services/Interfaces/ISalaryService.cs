using JobSearch.Business.DTOs.SalaryDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearch.Business.Services.Interfaces
{
    public interface ISalaryService
    {
        public IEnumerable<SalaryListItemDTO> GetAll();
        public Task CreateAsync(SalaryCreateDTO dto);
        Task Delete(int id);
        Task Update(int id, SalaryUpdateDTO dto);
    }
}
