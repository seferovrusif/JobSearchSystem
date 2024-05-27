using FluentValidation;

namespace JobSearch.Business.DTOs.VacancyDTOs
{
    public class VacancyShortInfoDTO
    {
        public int CompanyId { get; set; }
        public int CategoryId { get; set; }
        public string Position { get; set; }
        public int MaxSalaryId { get; set; }
        public int? MaxYas { get; set; }
        public int? MinYas { get; set; }
        public int GenderId { get; set; }
        public int EducationId { get; set; }
        public int ExperienceYearId { get; set; }
        public int CityId { get; set; }
        public int TypeOfVacancyId { get; set; }
        public int WorkTypeId { get; set; }
        public string AuthorizedPerson { get; set; }
        public DateTime DeadLine { get; set; }
    }
    public class VacancyShortInfoDTOValidator : AbstractValidator<VacancyShortInfoDTO>
    {
        public VacancyShortInfoDTOValidator()
        {

            RuleFor(a => a.Position)
                .NotEmpty()
                .NotNull()
                .MaximumLength(128);


            RuleFor(a => a.MaxYas)
                .LessThan(100);
            RuleFor(a => a.MinYas)
                .GreaterThan(13);
            RuleFor(a => a.AuthorizedPerson)
                .MaximumLength(64);
           


        }
    }
}
