namespace JobSearch.Core.Entities
{
    public class Category : BaseEntity 
    {
        public string Name { get; set; }
        public int? ParentId { get; set; }
        public IEnumerable<Category>?  Childs { get; set; }
        public Category Parent { get; set; }
        public IEnumerable<JobSeeker>? Seekers { get; set; }
        public IEnumerable<Vacancy>? Vacancies{ get; set; }
    }
}
