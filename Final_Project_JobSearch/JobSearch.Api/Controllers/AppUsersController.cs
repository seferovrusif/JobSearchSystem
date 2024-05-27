using JobSearch.Business.DTOs.AuthDTOs;
using JobSearch.Business.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace JobSearch.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUsersController : ControllerBase
    {
        IAppService _userService { get; }

        public AppUsersController(IAppService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public IEnumerable<string> GetAllRole()
        {
            return (IEnumerable<string>)Ok(_userService.GetAllRoles());
        }
    }
}
