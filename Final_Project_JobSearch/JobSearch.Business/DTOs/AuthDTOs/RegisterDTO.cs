using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearch.Business.DTOs.AuthDTOs
{
    public class RegisterDTO
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string UserName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

    }
    public class RegisterDTOValidator : AbstractValidator<RegisterDTO>
    {
        public RegisterDTOValidator()
        {
            RuleFor(a => a.Name)
                .NotNull()
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(32);
            RuleFor(a => a.Surname)
                .NotNull()
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(32);
            RuleFor(a => a.BirthDate)
                .NotNull()
                .NotEmpty()
                .LessThan(DateTime.Now.AddYears(-18))
                    .WithMessage("You must be over 18 years old");
            RuleFor(a => a.UserName)
                .NotNull()
                .NotEmpty()
                .MaximumLength(64)
                .MinimumLength(3);
            RuleFor(r => r.Email)
                .NotEmpty()
                .NotNull()
                .EmailAddress();
            RuleFor(r => r.Password)
                .NotNull()
                .NotEmpty()
                .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{6,}$");




        }

    }
}
