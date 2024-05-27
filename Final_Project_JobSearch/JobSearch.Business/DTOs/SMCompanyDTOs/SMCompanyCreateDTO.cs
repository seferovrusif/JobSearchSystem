using FluentValidation;

namespace JobSearch.Business.DTOs.SMCompanyDTOs
{
    public class SMCompanyCreateDTO
    {
        public int SocialMediaId { get; set; }
        public int CompanyId { get; set; }

        public string Username { get; set; }
    }
    public class SMCompanyCreateDTOValidator : AbstractValidator<SMCompanyCreateDTO>
    {
        public SMCompanyCreateDTOValidator()
        {
            RuleFor(a => a.Username)
                .NotEmpty()
                .NotNull()
                .MaximumLength(128);
            RuleFor(a => a.SocialMediaId)
                .NotEmpty()
                .NotNull()
                .GreaterThan(0);
            RuleFor(a => a.CompanyId)
                .NotEmpty()
                .NotNull()
                .GreaterThan(0);
        }
    }

}