using JobSearch.Business.DTOs.CompanyDTOs;
using JobSearch.Business.DTOs.SMCompanyDTOs;
using JobSearch.Business.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JobSearch.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        ICompanyService _service { get; }
        ISMCompanyService _addSMservice { get; }

        public CompaniesController(ICompanyService service, ISMCompanyService addSMservice)
        {
            _service = service;
            _addSMservice = addSMservice;
        }

        [HttpGet("GetAll")]
        [Authorize(Roles = "Admin" )]
        public IActionResult Get()
        {
            return Ok(_service.GetAll());
        }

        [HttpGet("GetAllActive")]
        [Authorize]
        public IActionResult GetActive()
        {
            return Ok(_service.GetAllActive());
        }
       
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateCompanyAsync(CompanyCreateDTO dto)
        {
            await _service.CreateAsync(dto);
            return Ok();
        }

        [HttpPost("AddSocialMedia")]
        [Authorize]
        public async Task<IActionResult> AddSMCompanyAsync(SMCompanyCreateDTO dto)
        {
            await _addSMservice.AddSM(dto);
            return Ok();
        }
        [HttpPut("SoftDelete")]
        [Authorize]
        public async Task<IActionResult> SoftDeleteCompanyAsync(int id)
        {
            await _service.SoftDelete(id);
            return Ok();
        }
        [HttpPut("ReverseSoftDelete")]
        [Authorize]
        public async Task<IActionResult> ReverseSoftDeleteCompanyAsync(int id)
        {
            await _service.ReverseSoftDelete(id);
            return Ok();
        }
        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> DeleteCompanyAsync(int id)
        {
            await _service.Delete(id);
            return Ok();
        }
        [HttpPut("Confirmed")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ConfirmedCompanyAsync(int id)
        {
            await _service.Confirmed(id);
            return Ok();
        }
        [HttpPut("ReverseConfirmed")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ReverseConfirmedCompanyAsync(int id)
        {
            await _service.ReverseConfirmed(id);
            return Ok();
        }
        [HttpPut("Update")]
        [Authorize]
        public async Task<IActionResult> UpdatedCompanyAsync(int id,CompanyUpdateDTO dto)
        {
            await _service.Update(id,dto);
            return Ok();
        }
        [HttpGet("GetById")]
        [Authorize]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _service.GetByIdAsync(id));
        }
    }
}
