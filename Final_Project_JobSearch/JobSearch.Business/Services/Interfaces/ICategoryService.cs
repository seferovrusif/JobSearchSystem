using JobSearch.Business.DTOs.CategoryDTOs;
using JobSearch.Business.DTOs.CityDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearch.Business.Services.Interfaces
{
    public interface ICategoryService
    {
        public IEnumerable<CategoryListItemDTO> GetAll();
        public Task CreateAsync(CategoryCreateDTO dto);
    }
}
