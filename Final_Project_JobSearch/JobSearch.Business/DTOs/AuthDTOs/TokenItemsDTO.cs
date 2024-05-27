using JobSearch.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearch.Business.DTOs.AuthDTOs
{
    public class TokenItemsDTO
    {
        public AppUser user { get; set; }
        public string role { get; set; }

    }
}
