using FluentValidation;

namespace JobSearch.Business.DTOs.SMCompanyDTOs
{
    public class SMCompanyListItemDTO
    {
        public int Id { get; set; }
        public DateTime CreatedTime { get; set; }
        public bool IsDleted { get; set; }
        public string SocialMediaId { get; set; }
        public string CompanyId { get; set; }

        public string Username { get; set; }
    }
    public class SMCompanyListItemDTOValidator : AbstractValidator<SMCompanyListItemDTO>
    {
        public SMCompanyListItemDTOValidator()
        {
            RuleFor(a => a.Username)
                .NotEmpty()
                .NotNull()
                .MaximumLength(128);
            RuleFor(a => a.SocialMediaId)
         .NotEmpty()
         .NotNull();
            RuleFor(a => a.CompanyId)
                .NotEmpty()
                .NotNull();
        }
    }

}