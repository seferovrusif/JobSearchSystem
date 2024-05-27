using JobSearch.Business.DTOs.AuthDTOs;
using JobSearch.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearch.Business.ExternalServices.Interfaces
{
    public interface ITokenService
    {
        TokenDTO CreateToken(TokenItemsDTO dto);
    }
}
