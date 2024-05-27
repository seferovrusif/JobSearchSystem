using JobSearch.Business.DTOs.PhoneDTOs;
using JobSearch.Business.Services.Interfaces;
using JobSearch.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobSearch.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhonesController : ControllerBase
    {
        IPhoneService _service { get; }

        public PhonesController(IPhoneService service)
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
    [Authorize]
        public async Task<IActionResult> CreatePhoneAsync(PhoneCreateDTO dto)
        {
            await _service.CreateAsync(dto);
            return Ok();
        }
    }
}
