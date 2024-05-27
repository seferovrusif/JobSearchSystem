using JobSearch.Business.DTOs.CompanyDTOs;
using JobSearch.Business.DTOs.JobSeekerDTOs;
using JobSearch.Business.DTOs.SMJobSeekerDTOs;
using JobSearch.Business.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JobSearch.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobSeekersController : ControllerBase
    {
        IJobSeekerService _service { get; }
        ISMJobSeekerService _addSMservice { get; }

        public JobSeekersController(IJobSeekerService service, ISMJobSeekerService addSMservice)
        {
            _service = service;
            _addSMservice = addSMservice;
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
        public async Task<IActionResult> CreateJobSeekerAsync(JobSeekerCreateDTO dto)
        {
            await _service.CreateAsync(dto);
            return Ok();
        }
        [HttpPost("AddSocialMedia")]
        [Authorize]
        public async Task<IActionResult> AddSMJobSeekerAsync(SMJobSeekerCreateDTO dto)
        {
            await _addSMservice.AddSM(dto);
            return Ok();
        }
        [HttpPut("SoftDelete")]
        [Authorize]
        public async Task<IActionResult> SoftDeleteJobSeekerAsync(int id)
        {
            await _service.SoftDelete(id);
            return Ok();
        }
        [HttpPut("ReverseSoftDelete")]
        [Authorize]
        public async Task<IActionResult> ReverseSoftDeleteJobSeekerAsync(int id)
        {
            await _service.ReverseSoftDelete(id);
            return Ok();
        }
        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> DeleteJobSeekerAsync(int id)
        {
            await _service.Delete(id);
            return Ok();
        }
        [HttpPut("Confirmed")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ConfirmedJobSeekerAsync(int id)
        {
            await _service.Confirmed(id);
            return Ok();
        }
        [HttpPut("ReverseConfirmed")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ReverseConfirmedJobSeekerAsync(int id)
        {
            await _service.ReverseConfirmed(id);
            return Ok();
        }
        [HttpPut("MakePremium")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> MakePremiumJobSeekerAsync(int id)
        {
            await _service.MakePremium(id);
            return Ok();
        }
        [HttpPut("ReversePremium")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ReversePremiumJobSeekerAsync(int id)
        {
            await _service.ReversePremium(id);
            return Ok();
        }
        [HttpPut("Update")]
        [Authorize]
        public async Task<IActionResult> UpdatedJobSeekerAsync(int id, JobSeekerUpdateDTO dto)
        {
            await _service.Update(id, dto);
            return Ok();
        }
       
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _service.GetByIdAsync(id));
        }
    }
}

