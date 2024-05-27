namespace JobSearch.Core.Entities
{
    public class ExperienceYear : BaseEntity
    {
        public string ExpYear { get; set; }
        public IEnumerable<JobSeeker>? Seekers { get; set; }
        public IEnumerable<Vacancy>? Vacancies { get; set; }


    }
}
