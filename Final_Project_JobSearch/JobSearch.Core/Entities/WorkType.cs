namespace JobSearch.Core.Entities
{
    public class WorkType : BaseEntity
    {
        public string Title { get; set; }

        public IEnumerable<Vacancy>? Vacancies { get; set; }
    }
}
