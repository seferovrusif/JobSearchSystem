using JobSearch.Business.DTOs.CityDTOs;
using JobSearch.Business.DTOs.EducationDTOs;
using JobSearch.Business.DTOs.ExperianceYearDTOs;
using JobSearch.Business.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobSearch.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExperienceYearsController : ControllerBase
    {
        IExperienceYearService _service { get; }

        public ExperienceYearsController(IExperienceYearService service)
        {
            _service = service;
        }

        [HttpGet]
    [Authorize]
        public IActionResult Get()
        {
            return Ok(_service.GetAll());
        }
        [HttpPost]
    [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateExperienceYearAsync(ExperienceYearCreateDTO dto)
        {
            await _service.CreateAsync(dto);
            return Ok();
        }
        [HttpPut("Update")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdatedAsync(int id, ExperienceYearUpdateDTO dto)
        {
            await _service.Update(id, dto);
            return Ok();
        }
        [HttpDelete]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _service.Delete(id);
            return Ok();
        }
    }
}
