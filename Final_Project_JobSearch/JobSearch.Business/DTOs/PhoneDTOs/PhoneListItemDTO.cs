using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearch.Business.DTOs.PhoneDTOs
{
     public class PhoneListItemDTO
    {
        public int Id { get; set; }
        public DateTime CreatedTime { get; set; }
        public bool IsDleted { get; set; }
        public string Number { get; set; }

    }
    public class PhoneListItemDTOValidator : AbstractValidator<PhoneListItemDTO>
    {
        public PhoneListItemDTOValidator()
        {
            RuleFor(a => a.Number)
                .NotEmpty()
                .NotNull()
                .MaximumLength(16)
                .MinimumLength(7);

        }
    }
}
