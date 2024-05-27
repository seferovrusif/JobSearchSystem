using FluentValidation;

namespace JobSearch.Business.DTOs.CategoryDTOs
{
    public class CategoryUpdateDTO
    {
        public string Name { get; set; }
        public int? ParentId { get; set; }
    }
    public class CategoryUpdateDTOValidator : AbstractValidator<CategoryUpdateDTO>
    {
        public CategoryUpdateDTOValidator()
        {
            RuleFor(a => a.Name)
                .NotEmpty()
                .NotNull()
                .MaximumLength(128);

            RuleFor(a => a.ParentId)
                .GreaterThan(0);
        }
    }

}