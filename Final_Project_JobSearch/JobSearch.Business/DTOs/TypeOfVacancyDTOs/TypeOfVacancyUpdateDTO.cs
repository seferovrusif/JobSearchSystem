using FluentValidation;

namespace JobSearch.Business.DTOs.TypeOfVacancyDTOs
{
    public class TypeOfVacancyUpdateDTO
    {
        public string Title { get; set; }
    }
    public class TypeOfVacancyUpdateDTOValidator : AbstractValidator<TypeOfVacancyUpdateDTO>
    {
        public TypeOfVacancyUpdateDTOValidator()
        {
            RuleFor(a => a.Title)
                .NotEmpty()
                .NotNull()
                .MaximumLength(32);
        }
    }
}