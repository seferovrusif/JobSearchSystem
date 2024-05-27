using JobSearch.Business.DTOs.EmailDTOs;
using JobSearch.Business.DTOs.PhoneDTOs;
using JobSearch.Business.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobSearch.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailsController : ControllerBase
    {
        IEmailService _service { get; }

        public EmailsController(IEmailService service)
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
        public async Task<IActionResult> CreateEmailAsync(EmailCreateDTO dto)
        {
            await _service.CreateAsync(dto);
            return Ok();
        }
    }
}
