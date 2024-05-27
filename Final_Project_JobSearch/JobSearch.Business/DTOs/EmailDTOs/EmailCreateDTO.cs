using FluentValidation;

namespace JobSearch.Business.DTOs.EmailDTOs
{
    public class EmailCreateDTO
    {
        public string EmailAddress { get; set; }
    }
    public class EmailCreateDTOValidator : AbstractValidator<EmailCreateDTO>
    {
        public EmailCreateDTOValidator()
        {
            RuleFor(x => x.EmailAddress)
                .NotNull()
                .NotEmpty()
                .EmailAddress()
                .MaximumLength(320);
        }
    }
}
