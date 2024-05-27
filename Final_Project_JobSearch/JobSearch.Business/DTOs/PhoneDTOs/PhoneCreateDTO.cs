using FluentValidation;
using JobSearch.Business.DTOs.AuthDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearch.Business.DTOs.PhoneDTOs
{
    public class PhoneCreateDTO
    {
        public string Number { get; set; }

    }
    public class PhoneCreateDTOValidator : AbstractValidator<PhoneCreateDTO>
    {
        public PhoneCreateDTOValidator()
        {
            RuleFor(a => a.Number)
                .NotEmpty()
                .NotNull()
                .MaximumLength(16)
                .MinimumLength(7);

        }
    }
}
