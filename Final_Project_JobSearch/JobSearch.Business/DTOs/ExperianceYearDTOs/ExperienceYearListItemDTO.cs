using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearch.Business.DTOs.ExperianceYearDTOs
{
    public class ExperienceYearListItemDTO
    {
        public int Id { get; set; }
        public DateTime CreatedTime { get; set; }
        public bool IsDleted { get; set; }
        public string ExpYear { get; set; }
    }
    public class ExperianceYearListItemDTODTOValidator : AbstractValidator<ExperienceYearListItemDTO>
    {
        public ExperianceYearListItemDTODTOValidator()
        {
            RuleFor(a => a.ExpYear)
                .NotNull()
                .NotEmpty()
                .MaximumLength(32);
        }
    }
}
