using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearch.Business.DTOs.SMJobSeekerDTOs
{
    public class SMJobSeekerCreateDTO
    {
            public int SocialMediaId { get; set; }
            public int JobSeekerId { get; set; }

        public string Username { get; set; }
    }
    public class SMJobSeekerCreateDTOValidator : AbstractValidator<SMJobSeekerCreateDTO>
    {
        public SMJobSeekerCreateDTOValidator()
        {
            RuleFor(a => a.Username)
                .NotEmpty()
                .NotNull()
                .MaximumLength(128);
            RuleFor(a => a.SocialMediaId)
                .NotEmpty()
                .NotNull()
                .GreaterThan(0);
            RuleFor(a => a.JobSeekerId)
                .NotEmpty()
                .NotNull()
                .GreaterThan(0);
        }
    }

}

