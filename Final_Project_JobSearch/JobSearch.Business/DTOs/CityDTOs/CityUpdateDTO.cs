using FluentValidation;

namespace JobSearch.Business.DTOs.CityDTOs
{
    public class CityUpdateDTO
    {
        public string Name { get; set; }
    }
    public class CityUpdateDTOValidator : AbstractValidator<CityUpdateDTO>
    {
        public CityUpdateDTOValidator()
        {
            RuleFor(a => a.Name)
                .NotEmpty()
                .NotNull()
                .MaximumLength(128);


        }
    }
}
