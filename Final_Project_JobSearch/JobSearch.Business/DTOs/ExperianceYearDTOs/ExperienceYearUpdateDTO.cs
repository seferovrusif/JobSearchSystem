using FluentValidation;

namespace JobSearch.Business.DTOs.ExperianceYearDTOs
{
    public class ExperienceYearUpdateDTO
    {
        public string ExpYear { get; set; }
    }
    public class ExperienceYearUpdateDTOValidator : AbstractValidator<ExperienceYearUpdateDTO>
    {
        public ExperienceYearUpdateDTOValidator()
        {
            RuleFor(a => a.ExpYear)
                .NotNull()
                .NotEmpty()
                .MaximumLength(32);
        }
    }
}
