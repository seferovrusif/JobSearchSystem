namespace JobSearch.Core.Entities
{
    public class Salary : BaseEntity
    {
        public string Amount{ get; set; }
        public IEnumerable<Vacancy>? Vacancies { get; set; }
    }
}
