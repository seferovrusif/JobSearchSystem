using JobSearch.Business.DTOs.SalaryDTOs;
using JobSearch.Business.DTOs.SocialMediaDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearch.Business.Services.Interfaces
{
    public interface ISocialMediaService
    {
        public IEnumerable<SocialMediaListItemDTO> GetAll();
        public Task CreateAsync(SocialMediaCreateDTO dto);
    }
}
