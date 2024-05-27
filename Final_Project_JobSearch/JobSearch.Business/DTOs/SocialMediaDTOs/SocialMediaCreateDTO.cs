using FluentValidation;

namespace JobSearch.Business.DTOs.SocialMediaDTOs
{
    public class SocialMediaCreateDTO
    {
        public string Title { get; set; }
        public string Icon { get; set; }
        public string MainLink { get; set; }
    }
    public class SocialMediaCreateDTOValidator : AbstractValidator<SocialMediaCreateDTO>
    {
        public SocialMediaCreateDTOValidator()
        {
            RuleFor(a => a.Title)
                .MaximumLength(32)
                .NotEmpty()
                .NotNull();
            RuleFor(a => a.MainLink)
                .MaximumLength(128)
                .NotEmpty()
                .NotNull();
            RuleFor(a => a.Icon)
                .MaximumLength(128)
                .NotEmpty()
                .NotNull();
        }
    }
}
