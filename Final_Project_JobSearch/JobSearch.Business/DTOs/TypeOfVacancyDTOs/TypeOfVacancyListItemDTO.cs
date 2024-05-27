using FluentValidation;

namespace JobSearch.Business.DTOs.TypeOfVacancyDTOs
{
    public class TypeOfVacancyListItemDTO
    {
        public int Id { get; set; }
        public DateTime CreatedTime { get; set; }
        public bool IsDleted { get; set; }
        public string Title { get; set; }
    }
    public class TypeOfVacancyListItemDTOValidator : AbstractValidator<TypeOfVacancyListItemDTO>
    {
        public TypeOfVacancyListItemDTOValidator()
        {
            RuleFor(a => a.Title)
                .NotEmpty()
                .NotNull()
                .MaximumLength(32);
        }
    }
}
