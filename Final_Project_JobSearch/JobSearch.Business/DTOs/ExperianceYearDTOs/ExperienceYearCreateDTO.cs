using FluentValidation;

namespace JobSearch.Business.DTOs.ExperianceYearDTOs
{
    public class ExperienceYearCreateDTO
    {
        public string ExpYear { get; set; }
    }
    public class ExperianceYearCreateDTOValidator : AbstractValidator<ExperienceYearCreateDTO>
    {
        public ExperianceYearCreateDTOValidator()
        {
            RuleFor(a => a.ExpYear)
                .NotNull()
                .NotEmpty()
                .MaximumLength(32);
        }
    }
}
