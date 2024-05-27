using FluentValidation;

namespace JobSearch.Business.DTOs.EducationDTOs
{
    public class EducationCreateDTO
    {
        public string Degree { get; set; }
    }
    public class EducationCreateDTOValidtor : AbstractValidator<EducationCreateDTO>
    {
        public EducationCreateDTOValidtor()
        {
            RuleFor(a=>a.Degree)
                .NotEmpty()
                .NotNull()
                .MaximumLength(32);
        }
    }
}
