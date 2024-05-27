using AutoMapper;
using JobSearch.Business.ExternalServices.Interfaces;
using JobSearch.Business.Services.Interfaces;
using JobSearch.Core.Entities;
using JobSearch.Core.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace JobSearch.Business.Services.Implements
{
    public class AppService : IAppService
    {
        UserManager<AppUser> _userManager { get; }
        readonly string userId;
        IHttpContextAccessor _contextAccessor { get; }

        public AppService(UserManager<AppUser> userManager, IHttpContextAccessor contextAccessor)
        {
            _userManager = userManager;
            _contextAccessor = contextAccessor;
            if (_contextAccessor.HttpContext.User.Claims.Any())
            {
                userId = _contextAccessor.HttpContext?.User?.Claims?.First(x => x.Type == ClaimTypes.NameIdentifier)?.Value ?? throw new NullReferenceException();
            }
        }
        public async Task ChangeRoleAsync(string userId, string role)
        {
           AppUser user = await _userManager.FindByIdAsync(userId);

           await _userManager.AddToRoleAsync(user, role);

        }

        public IEnumerable<string> GetAllRoles()
        {
            IEnumerable<string> roles = new List<string>();
            foreach (var role in Enum.GetNames(typeof(Roles)))
            {
                roles.Append(role);
            }
            return roles;
        }

        public Task ChangeRole(string userId, string role)
        {
            throw new NotImplementedException();
        }
    }
}
