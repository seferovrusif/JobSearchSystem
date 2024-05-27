using FluentValidation;

namespace JobSearch.Business.DTOs.VacancyDTOs
{
    public class VacancyInfoDTO
    {
        public int CompanyId { get; set; }
        public int EmailId { get; set; }
        public int PhoneId { get; set; }
        public int CategoryId { get; set; }
        public string Position { get; set; }
        public int MaxSalaryId { get; set; }
        public string AboutWork { get; set; }
        public string Requirements { get; set; }
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
        public string Website { get; set; }
    }
    public class VacancyInfoDTOValidator : AbstractValidator<VacancyInfoDTO>
    {
        public VacancyInfoDTOValidator()
        {
            RuleFor(x => x.EmailId)
                .NotEmpty()
                .NotNull()
                .GreaterThan(0);
            RuleFor(a => a.PhoneId)
               .NotEmpty()
               .NotNull()
               .GreaterThan(0);
            RuleFor(a => a.CategoryId)
                .NotEmpty()
                .NotNull()
                .GreaterThan(0); 
            RuleFor(a => a.CompanyId)
                .NotEmpty()
                .NotNull()
                .GreaterThan(0);
            RuleFor(a => a.Position)
                .NotEmpty()
                .NotNull()
                .MaximumLength(128);

            RuleFor(a => a.AboutWork)
                .NotEmpty()
                .NotNull()
                .MaximumLength(1024);
            RuleFor(a => a.Requirements)
                .NotEmpty()
                .NotNull()
                .MaximumLength(1024);

            RuleFor(a => a.MaxYas)
                .LessThan(100);
            RuleFor(a => a.MinYas)
                .GreaterThan(13);
            RuleFor(a => a.AuthorizedPerson)
                .MaximumLength(64);
            RuleFor(a => a.DeadLine)
                .GreaterThan(DateTime.Now);
            RuleFor(a => a.Website)
                .MaximumLength(256);


        }
    }
}
