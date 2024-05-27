using JobSearch.Business.DTOs.CompanyDTOs;
using JobSearch.Business.DTOs.VacancyDTOs;
using JobSearch.Business.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JobSearch.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VacanciesController : ControllerBase
    {
        IVacancyService _service { get; }

        public VacanciesController(IVacancyService service)
        {
            _service = service;
        }

        [HttpGet("GetAll")]
        [Authorize(Roles = "Admin")]
        public IActionResult Get()
        {
            return Ok(_service.GetAll());
        }

        [HttpGet("GetAllActive")]
        public IActionResult GetActive()
        {
            return Ok(_service.GetAllActive());
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateVacancyAsync(VacancyCreateDTO dto)
        {
            await _service.CreateAsync(dto);
            return Ok();
        }
        [HttpPut("SoftDelete")]
        [Authorize]
        public async Task<IActionResult> SoftDeleteVacancyAsync(int id)
        {
            await _service.SoftDelete(id);
            return Ok();
        }
        [HttpPut("ReverseSoftDelete")]
        [Authorize]
        public async Task<IActionResult> ReverseSoftDeleteVacancyAsync(int id)
        {
            await _service.ReverseSoftDelete(id);
            return Ok();
        }
        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> DeleteVacancyAsync(int id)
        {
            await _service.Delete(id);
            return Ok();
        }
        [HttpPut("Confirmed")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ConfirmedVacancyAsync(int id)
        {
            await _service.Confirmed(id);
            return Ok();
        }
        [HttpPut("ReverseConfirmed")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ReverseConfirmedVacancyAsync(int id)
        {
            await _service.ReverseConfirmed(id);
            return Ok();
        }
        [HttpPut("MakePremium")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> MakePremiumVacancyAsync(int id)
        {
            await _service.MakePremium(id);
            return Ok();
        }
        [HttpPut("ReversePremium")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ReversePremiumVacancyAsync(int id)
        {
            await _service.ReversePremium(id);
            return Ok();
        }
        [HttpPut("Update")]
        [Authorize]
        public async Task<IActionResult> UpdatedVacancyAsync(int id, VacancyUpdateDTO dto)
        {
            await _service.Update(id, dto);
            return Ok();
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _service.GetByIdAsync(id));
        }
        [HttpGet("GetById(ShortInfo)")]
        public async Task<IActionResult> GetByIdShort(int id)
        {
            return Ok(await _service.GetByIdShortAsync(id));
        }
    }
}

