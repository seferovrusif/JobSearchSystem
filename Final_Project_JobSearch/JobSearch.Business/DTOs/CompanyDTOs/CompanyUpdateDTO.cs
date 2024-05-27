using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearch.Business.DTOs.CompanyDTOs
{
    public class CompanyUpdateDTO
    {
        public string Name { get; set; }
        public string About { get; set; }
        //public string Email { get; set; }
        //public string Phone { get; set; }
        public string AuthorizedPerson { get; set; }
        public string Website { get; set; }
    }
    public class CompanyUpdateDTOValidator : AbstractValidator<CompanyUpdateDTO>
    {
        public CompanyUpdateDTOValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull()
                .MaximumLength(32);
            RuleFor(x => x.About)
                .MaximumLength(2048);
           
            RuleFor(x => x.AuthorizedPerson)
                .NotEmpty()
                .NotNull()
                .MaximumLength(64)
                .MinimumLength(3);
            RuleFor(x => x.Website)
                .NotEmpty()
                .NotNull()
                .MaximumLength(256);
        }
    }
}
