using FluentValidation;

namespace JobSearch.Business.DTOs.CityDTOs
{
    public class CityCreateDTO
    {
        public string Name { get; set; }
    }
    public class CityCreateDTOValidator : AbstractValidator<CityCreateDTO>
    {
        public CityCreateDTOValidator()
        {
            RuleFor(a => a.Name)
                .NotEmpty()
                .NotNull()
                .MaximumLength(128);


        }
    }
}
