namespace JobSearch.Core.Entities
{
    public class Phone : BaseEntity
    {
        public string Number { get; set; }
        public IEnumerable<JobSeeker>? Seekers { get; set; }
        public IEnumerable<Vacancy>? Vacancies { get; set; }
        ///TODO:Elaqeni belke deyisidim
    }
}
