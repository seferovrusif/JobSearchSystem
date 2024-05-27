using FluentValidation;

namespace JobSearch.Business.DTOs.CompanyDTOs
{
    public class CompanyCreateDTO
    {
        public string Name { get; set; }
        public string About { get; set; }
        //public string Email { get; set; }
        //public string Phone { get; set; }
        public string AuthorizedPerson { get; set; }
        public string Website { get; set; }
    }
    public class CompanyCreateDTOValidator : AbstractValidator<CompanyCreateDTO>
    {
        public CompanyCreateDTOValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull()
                .MaximumLength(32);
            RuleFor(x => x.About)
                .MaximumLength(2048);

            RuleFor(x => x.AuthorizedPerson)
                .NotEmpty()
                .NotNull()
                .MaximumLength(64)
                .MinimumLength(3);
            RuleFor(x => x.Website)
                .NotEmpty()
                .NotNull()
                .MaximumLength(256);
        }
    }
}
