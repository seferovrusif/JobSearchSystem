namespace JobSearch.Core.Entities
{
    public class SocialMediaCompany:BaseEntity
    { 
        public int SocialMediaId { get; set; }
        public SocialMedia SocialMedia { get; set; }
        public int CompanyId { get; set; }
        public Company? Company { get; set; }
        public string Username { get; set; }

    }
}
