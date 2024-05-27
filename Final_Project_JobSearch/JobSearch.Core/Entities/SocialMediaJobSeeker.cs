namespace JobSearch.Core.Entities
{
    public class SocialMediaJobSeeker:BaseEntity
    {
        public int SocialMediaId { get; set; }
        public SocialMedia? SocialMedia { get; set; }
        public int JobSeekerId { get; set; }
        public JobSeeker? JobSeeker { get; set; }
        public string Username { get; set; }
    }
}
