using FluentValidation;

namespace JobSearch.Business.DTOs.VacancyDTOs
{
    public class VacancyListItemDTO
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public int CompanyId { get; set; }
        public string CompanyAbout { get; set; }
        //public string UserName { get; set; }
        public DateTime CreatedTime { get; set; }
        public bool IsDleted { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Category { get; set; }
        public string Position { get; set; }
        public int MaxSalary { get; set; }
        public string AboutWork { get; set; }
        public string Requirements { get; set; }
        public int? MaxYas { get; set; }
        public int? MinYas { get; set; }
        public string Gender { get; set; }
        public string EducationId { get; set; }
        public string ExperienceYear { get; set; }
        public string City { get; set; }
        public string TypeOfVacancy { get; set; }
        public string WorkType { get; set; }
        public string AuthorizedPerson { get; set; }
        public DateTime DeadLine { get; set; }
        public string Website { get; set; }
    }
    public class VacancyListItemDTOValidator : AbstractValidator<VacancyListItemDTO>
    {
        public VacancyListItemDTOValidator()
        {
            
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
