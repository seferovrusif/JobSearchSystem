using FluentValidation;

namespace JobSearch.Business.DTOs.SalaryDTOs
{
    public class SalaryCreateDTO
    {
        public string Amount { get; set; }
    }
    public class SalaryCreateDTOValidator : AbstractValidator<SalaryCreateDTO>
    {
        public SalaryCreateDTOValidator()
        {
            RuleFor(a => a.Amount)
                .NotEmpty()
                .NotNull()
                .MaximumLength(16);
        }
    }
}
