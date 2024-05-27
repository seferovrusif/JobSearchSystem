using FluentValidation;

namespace JobSearch.Business.DTOs.GenderDTOs
{
    public class GenderUpdateDTO
    {
        public string Title { get; set; }

    }
    public class GenderUpdateDTOValidator : AbstractValidator<GenderUpdateDTO>
    {
        public GenderUpdateDTOValidator()
        {
            RuleFor(a => a.Title)
                .NotEmpty()
                .NotNull()
                .MaximumLength(16);

        }
    }
}
