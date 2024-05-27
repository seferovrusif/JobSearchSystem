using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearch.Business.DTOs.CompanyDTOs
{
    public class CompanyListItemDTO
    {
        public int Id { get; set; }
        public DateTime CreatedTime { get; set; }
        public bool IsDleted { get; set; }
        public string Name { get; set; }
        public string About { get; set; }
        //public string EmailAddress { get; set; }
        //public string Number { get; set; }
        public string AuthorizedPerson { get; set; }
        public string Website { get; set; }
    }
    public class CompanyListItemDTOValidator : AbstractValidator<CompanyListItemDTO>
    {
        public CompanyListItemDTOValidator()
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