using AutoMapper;
using JobSearch.Business.DTOs.AuthDTOs;
using JobSearch.Business.Exceptions.AppUser;
using JobSearch.Business.ExternalServices.Interfaces;
using JobSearch.Business.Services.Interfaces;
using JobSearch.Core.Entities;
using JobSearch.Core.Enums;
using Microsoft.AspNetCore.Identity;
using System.Text;

namespace JobSearch.Business.Services.Implements
{
    public class AuthService:IAuthService
    {
        UserManager<AppUser> _userManager { get; }
        ITokenService _tokenService { get; }
        IMapper _mapper { get; }

        public AuthService(UserManager<AppUser> userManager, IMapper mapper, ITokenService tokenService)
        {
            _userManager = userManager;
            _mapper = mapper;
            _tokenService = tokenService;
        }
        public async Task CreateAsync(RegisterDTO dto)
        {
            AppUser user = _mapper.Map<AppUser>(dto);
            var result = await _userManager.CreateAsync(user, dto.Password);
            if (!result.Succeeded)
            {
                ///TODO: belke strbuilderi liste deyisdim
                StringBuilder sb = new();
                foreach (var item in result.Errors)
                {
                    sb.Append(item.Description + " ");
                }
                throw new AppUserRegisterFailedException(sb.ToString().TrimEnd());
            }
            var roleResult = await _userManager.AddToRoleAsync(user, nameof(Roles.Member));
            if (!roleResult.Succeeded)
            {
                StringBuilder sb = new();
                foreach (var item in result.Errors)
                {
                    sb.Append(item.Description + " ");
                }
                throw new AppUserRegisterFailedException(sb.ToString().TrimEnd());
            }
        }

        public async Task<TokenDTO> Login(LoginDTO dto)
        {
            AppUser User;
            if (dto.UserNameOrEmail.Contains("@"))
            {
                User= await _userManager.FindByEmailAsync(dto.UserNameOrEmail);
            }
            else
            {
                User = await _userManager.FindByNameAsync(dto.UserNameOrEmail);
            }
            if (User == null) throw new PasswordOrUserNameWrongException();
            var result =await _userManager.CheckPasswordAsync(User, dto.Password);
            if (!result) throw new PasswordOrUserNameWrongException();
            string Role = (await _userManager.GetRolesAsync(User)).First();
            return _tokenService.CreateToken(new TokenItemsDTO
            {
                role = Role,
                user = User
            });
        }

    
    }
}
