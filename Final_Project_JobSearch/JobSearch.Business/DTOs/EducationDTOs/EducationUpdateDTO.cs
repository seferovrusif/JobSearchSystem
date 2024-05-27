using FluentValidation;

namespace JobSearch.Business.DTOs.EducationDTOs
{
    public class EducationUpdateDTO
    {   public string Degree { get; set; }
    }
    public class EducationUpdateDTOValidtor : AbstractValidator<EducationUpdateDTO>
    {
        public EducationUpdateDTOValidtor()
        {
            RuleFor(a=>a.Degree)
                .NotEmpty()
                .NotNull()
                .MaximumLength(32);
        }
    }
}
