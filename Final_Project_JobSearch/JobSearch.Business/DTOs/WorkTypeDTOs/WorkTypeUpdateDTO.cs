using FluentValidation;

namespace JobSearch.Business.DTOs.WorkTypeDTOs
{
    public class WorkTypeUpdateDTO
    {
        public string Title { get; set; }
    }
    public class WorkTypeUpdateDTOValidator : AbstractValidator<WorkTypeUpdateDTO>
    {
        public WorkTypeUpdateDTOValidator()
        {
            RuleFor(a => a.Title)
                .NotEmpty()
                .NotNull()
                .MaximumLength(32);
        }
    }
}