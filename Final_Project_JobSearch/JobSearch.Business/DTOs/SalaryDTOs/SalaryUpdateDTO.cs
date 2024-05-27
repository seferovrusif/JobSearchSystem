using FluentValidation;

namespace JobSearch.Business.DTOs.SalaryDTOs
{
    public class SalaryUpdateDTO
    {
        public string Amount { get; set; }
    }
    public class SalaryUpdateDTOValidator : AbstractValidator<SalaryUpdateDTO>
    {
        public SalaryUpdateDTOValidator()
        {
            RuleFor(a => a.Amount)
                .NotEmpty()
                .NotNull()
                .MaximumLength(16);
        }
    }
}
