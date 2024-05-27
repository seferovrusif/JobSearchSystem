using FluentValidation;

namespace JobSearch.Business.DTOs.WorkTypeDTOs
{
    public class WorkTypeCreateDTO
    {
        public string Title { get; set; }
    }
    public class WorkTypeCreateDTOValidator : AbstractValidator<WorkTypeCreateDTO>
    {
        public WorkTypeCreateDTOValidator()
        {
            RuleFor(a => a.Title)
                .NotEmpty()
                .NotNull()
                .MaximumLength(32);
        }
    }
}