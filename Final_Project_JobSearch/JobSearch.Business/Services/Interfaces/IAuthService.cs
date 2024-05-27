using AutoMapper;
using JobSearch.Business.DTOs.AuthDTOs;
using JobSearch.Business.ExternalServices.Interfaces;
using JobSearch.Core.Entities;
using Microsoft.AspNetCore.Identity;

namespace JobSearch.Business.Services.Interfaces
{
    public interface IAuthService
    {

        public Task<TokenDTO> Login(LoginDTO dto);
        public Task CreateAsync(RegisterDTO dto);

    }
}
