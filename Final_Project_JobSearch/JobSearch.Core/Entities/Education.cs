namespace JobSearch.Core.Entities
{
    public class Education : BaseEntity
    {
        public string Degree { get; set; }
        public IEnumerable<JobSeeker>? Seekers { get; set; }
        public IEnumerable<Vacancy>? Vacancies { get; set; }

    }
}
