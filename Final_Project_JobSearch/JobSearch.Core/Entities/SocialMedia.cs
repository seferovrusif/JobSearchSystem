namespace JobSearch.Core.Entities
{
    public class SocialMedia : BaseEntity
    {
        public string Title { get; set; }
        public string Icon { get; set; }
        public string MainLink { get; set; }
        public IEnumerable<SocialMediaCompany>? SocialMediaCompanies { get; set; }
        public IEnumerable<SocialMediaJobSeeker>? SocialMediaJobSeekers { get; set; }
    }
}
