using FluentValidation;

namespace JobSearch.Business.DTOs.WorkTypeDTOs
{
    public class WorkTypeListItemDTO
    {
        public int Id { get; set; }
        public DateTime CreatedTime { get; set; }
        public bool IsDleted { get; set; }
        public string Title { get; set; }
    }
    public class WorkTypeListItemDTOValidator : AbstractValidator<WorkTypeListItemDTO>
    {
        public WorkTypeListItemDTOValidator()
        {
            RuleFor(a => a.Title)
                .NotEmpty()
                .NotNull()
                .MaximumLength(32);
        }
    }
} 