namespace JobSearch.Core.Entities
{
    public class Company : BaseEntity
    {
        public string UserId { get; set; }
        public AppUser? User { get; set; }
        public string Name { get; set; }
        public string About { get; set; }
    
        public string AuthorizedPerson { get; set; }
        ///TODO: belke ayri table a cixardim
        public string Website { get; set; }
        public bool IsConfirmed { get; set; }
        public IEnumerable<SocialMediaCompany>? SocialMediaCompany { get; set; }
        public IEnumerable<Vacancy>? Vacancies { get; set; }

    }
}
