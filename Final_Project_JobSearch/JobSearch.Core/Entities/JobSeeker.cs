namespace JobSearch.Core.Entities
{
    public class JobSeeker : BaseEntity
    {
        public string UserId { get; set; }
        public AppUser? User { get; set; }
        public int EmailId { get; set; }
        public Email? Email { get; set; }
        public int PhoneId { get; set; }
        public Phone? Phone { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string FatherName { get; set; }
        public string ImageUrl { get; set; }
        public string CVImgUrl { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }

        public int GenderId { get; set; }
        public Gender? Gender { get; set; }
        public int EducationId { get; set; }
        public Education? Education { get; set; }
        public string EducationDetail { get; set; }
        public int ExperienceYearId { get; set; }
        public ExperienceYear? ExperienceYear { get; set; }
        public string ExperienceDetail { get; set; }
        public string Position{ get; set; }
        public int CityId { get; set; }
        public City? City { get; set; }
        ///TODO: belke ayri table a cixardim
        public string Skills { get; set; }
        public string LanguageSkills { get; set; }
        public string AdditionalInformation{ get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime LastActiveTime { get; set; }
        public bool IsPremium{ get; set; }
        public bool IsConfirmed { get; set; }
        public IEnumerable<SocialMediaJobSeeker>? SocialMediaJobSeekers { get; set; }
    }
}
