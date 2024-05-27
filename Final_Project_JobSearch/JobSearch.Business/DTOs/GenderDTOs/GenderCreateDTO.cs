using FluentValidation;
using JobSearch.Business.DTOs.PhoneDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearch.Business.DTOs.GenderDTOs
{
    public class GenderCreateDTO
    {
        public string Title { get; set; }

    }
    public class GenderCreateDTOValidator : AbstractValidator<GenderCreateDTO>
    {
        public GenderCreateDTOValidator()
        {
            RuleFor(a => a.Title)
                .NotEmpty()
                .NotNull()
                .MaximumLength(16);

        }
    }
}