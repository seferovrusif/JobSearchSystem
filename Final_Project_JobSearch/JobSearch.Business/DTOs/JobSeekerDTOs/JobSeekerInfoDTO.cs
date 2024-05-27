using FluentValidation;

namespace JobSearch.Business.DTOs.JobSeekerDTOs
{
    public class JobSeekerInfoDTO
    {
        public int EmailId { get; set; }
        public int PhoneId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string FatherName { get; set; }
        public string ImageUrl { get; set; }
        public string CVImgUrl { get; set; }
        public int CategoryId { get; set; }
        public int GenderId { get; set; }
        public int EducationId { get; set; }
        public string EducationDetail { get; set; }
        public int ExperienceYearId { get; set; }
        public string ExperienceDetail { get; set; }
        public string Position { get; set; }
        public int CityId { get; set; }
        public string Skills { get; set; }
        public string LanguageSkills { get; set; }
        public string AdditionalInformation { get; set; }
        public DateTime BirthDate { get; set; }
    }
    public class JobSeekerInfoDTOValidator : AbstractValidator<JobSeekerInfoDTO>
    {
        public JobSeekerInfoDTOValidator()
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
            RuleFor(a => a.Skills)
                .NotEmpty()
                .NotNull()
                .MaximumLength(1024);
            RuleFor(a => a.LanguageSkills)
              .MaximumLength(512);
            RuleFor(a => a.Position)
               .NotEmpty()
               .NotNull()
               .MaximumLength(128);
            RuleFor(a => a.Name)
               .NotEmpty()
               .NotNull()
               .MaximumLength(32);
            RuleFor(a => a.Surname)
               .NotEmpty()
               .NotNull()
               .MaximumLength(32);
            RuleFor(a => a.FatherName)
               .NotEmpty()
               .NotNull()
               .MaximumLength(32);
            RuleFor(a => a.AdditionalInformation)
               .MaximumLength(1024);
            RuleFor(a => a.BirthDate)
                .LessThan(DateTime.Now.AddYears(13));
            RuleFor(a => a.ExperienceDetail)
              .NotEmpty()
              .NotNull()
              .MaximumLength(1024);
            RuleFor(a => a.EducationDetail)
              .NotEmpty()
              .NotNull()
              .MaximumLength(1024);
            RuleFor(a => a.CVImgUrl)
              .MaximumLength(64);
            RuleFor(a => a.ImageUrl)
              .MaximumLength(64);
        }
    }
}