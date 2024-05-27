namespace JobSearch.Core.Entities
{
    public class TypeOfVacancy:BaseEntity
    {
        public string Title { get; set; }
        public IEnumerable<Vacancy>? Vacancies { get; set; }

    }
}
