using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearch.Business.DTOs.AuthDTOs
{
    public class LoginDTO
    {
        public string UserNameOrEmail { get; set; }
        public string Password { get; set; }

    }
    public class LoginDTOValidator : AbstractValidator<LoginDTO>
    {
        public LoginDTOValidator()
        {
            RuleFor(a => a.UserNameOrEmail)
                .NotEmpty()
                .NotNull()
                .MaximumLength(320)
                .MinimumLength(3);

            RuleFor(a => a.Password)
                .NotEmpty()
                .NotNull()
                .MaximumLength(64)
                .MinimumLength(6);  

        }
    }
}
