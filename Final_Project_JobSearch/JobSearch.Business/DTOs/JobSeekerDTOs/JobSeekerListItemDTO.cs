using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearch.Business.DTOs.JobSeekerDTOs
{
    public class JobSeekerListItemDTO
    {
        public int Id { get; set; }
        public DateTime CreatedTime { get; set; }
        public bool IsDleted { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string FatherName { get; set; }
        public string ImageUrl { get; set; }
        public string CVImgUrl { get; set; }
        public string Category  { get; set; }
        public string Gender  { get; set; }
        public string EducationId  { get; set; }
        public string EducationDetail { get; set; }
        public string ExperienceYear  { get; set; }
        public string ExperienceDetail { get; set; }
        public string Position { get; set; }
        public string City  { get; set; }
        public string Skills { get; set; }
        public string LanguageSkills { get; set; }
        public string AdditionalInformation { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime LastActiveTime { get; set; }
    }
    public class JobSeekerListItemDTOValidator : AbstractValidator<JobSeekerListItemDTO>
    {
        public JobSeekerListItemDTOValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .NotNull()
                .EmailAddress()
                .MaximumLength(320);
            RuleFor(a => a.Phone)
               .NotEmpty()
               .NotNull()
               .MaximumLength(16)
               .MinimumLength(7);
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