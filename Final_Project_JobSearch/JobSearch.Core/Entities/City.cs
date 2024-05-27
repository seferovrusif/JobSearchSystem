namespace JobSearch.Core.Entities
{
    public class City : BaseEntity
    {
        public string Name { get; set; }
        public IEnumerable<JobSeeker>? Seekers { get; set; }
        public IEnumerable<Vacancy>? Vacancies { get; set; }
        ///TODO: Company ilede elaqe qur
    }
}
