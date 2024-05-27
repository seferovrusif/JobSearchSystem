using JobSearch.Business.DTOs.AuthDTOs;
using JobSearch.Business.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JobSearch.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthsController : ControllerBase
    {
        IAuthService _userservice { get; }
        public AuthsController(IAuthService userservice)
        {
            _userservice = userservice;
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterDTO dto)
        {
            await _userservice.CreateAsync(dto);
            return Ok(dto);
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDTO dto)
        {
            TokenDTO a = await _userservice.Login(dto);
            return Ok(a);
        }
    }
}
