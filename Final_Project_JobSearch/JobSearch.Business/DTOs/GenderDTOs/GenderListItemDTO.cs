using FluentValidation;

namespace JobSearch.Business.DTOs.GenderDTOs
{
    public class GenderListItemDTO
    {
        public int Id { get; set; }
        public DateTime CreatedTime { get; set; }
        public bool IsDleted { get; set; }
        public string Title { get; set; }

    }
    public class GenderListItemDTOValidator : AbstractValidator<GenderListItemDTO>
    {
        public GenderListItemDTOValidator()
        {
            RuleFor(a => a.Title)
                .NotEmpty()
                .NotNull()
                .MaximumLength(16);

        }
    }
}
  