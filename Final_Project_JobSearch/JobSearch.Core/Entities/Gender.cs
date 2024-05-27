namespace JobSearch.Core.Entities
{
    public class Gender : BaseEntity
    {
        public string Title { get; set; }
        public IEnumerable<JobSeeker>? Seekers { get; set; }
        public IEnumerable<Vacancy>? Vacancies { get; set; }
    }
}
