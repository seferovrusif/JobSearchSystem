using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearch.Business.DTOs.AuthDTOs
{
    public class TokenDTO
    {
        public string token { get; set; }
        public DateTime expireTime { get; set; }
    }
}
