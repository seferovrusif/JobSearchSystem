using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearch.Business.DTOs.EmailDTOs
{
    public class EmailListItemDTO
    {
        ///TODO:Admin ucun isdelete olan versiyasini haazirla butub dtolarda
        public int Id { get; set; }
        public DateTime CreatedTime { get; set; }
        public bool IsDleted { get; set; }
        public string EmailAddress { get; set; }
    }
    public class EmailListItemDTOValidator : AbstractValidator<EmailListItemDTO>
    {
        public EmailListItemDTOValidator()
        {
            RuleFor(x => x.EmailAddress)
                .NotNull()
                .NotEmpty()
                .EmailAddress()
                .MaximumLength(320);
        }
    }
}
