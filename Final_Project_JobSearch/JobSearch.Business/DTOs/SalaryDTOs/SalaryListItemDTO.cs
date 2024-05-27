using FluentValidation;

namespace JobSearch.Business.DTOs.SalaryDTOs
{
    public  class SalaryListItemDTO
    {
        public int Id { get; set; }
        public DateTime CreatedTime { get; set; }
        public bool IsDleted { get; set; }
        public string Amount { get; set; }
    }
    public class SalarySalaryListItemDTOValidator : AbstractValidator<SalaryListItemDTO>
    {
        public SalarySalaryListItemDTOValidator()
        {
            RuleFor(a=>a.Amount)
                .NotEmpty()
                .NotNull()
                .MaximumLength(16);
        }
    }
}
