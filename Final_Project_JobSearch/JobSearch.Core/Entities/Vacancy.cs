namespace JobSearch.Core.Entities
{
    public class Vacancy : BaseEntity
    {
        public int EmailId { get; set; }
        public Email? Email { get; set; }
        public int PhoneId { get; set; }
        public Phone? Phone { get; set; }
        public int CompanyId { get; set; }
        public Company? Company { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        public string Position { get; set; }
        //public int MinSalaryId { get; set; }
        //public Salary? MinSalary { get; set; }
        public int MaxSalaryId { get; set; }
        public Salary? MaxSalary { get; set; }
        public string AboutWork { get; set; }
        public string Requirements { get; set; }
        public int? MaxYas { get; set; }
        public int? MinYas { get; set; }
        public int GenderId { get; set; }
        public Gender? Gender { get; set; }
        public int EducationId { get; set; }
        public Education? Education { get; set; }
        public int ExperienceYearId { get; set; }
        public ExperienceYear? ExperienceYear { get; set; }
        public int CityId { get; set; }
        public City? City { get; set; }
        public int TypeOfVacancyId { get; set; }
        public TypeOfVacancy? TypeOfVacancy { get; set; }
        public int WorkTypeId { get; set; }
        public WorkType? WorkType { get; set; }
        public string AuthorizedPerson { get; set; }
        public DateTime DeadLine { get; set; }
        public DateTime LastActiveTime { get; set; }
        public string Website { get; set; }
        public bool IsPremium { get; set; }
        public bool IsConfirmed { get; set; }

    }
}
