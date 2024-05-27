namespace JobSearch.Core.Entities
{
    public class Email : BaseEntity
    {
        public string EmailAddress { get; set; }
        public IEnumerable<JobSeeker>? Seekers { get; set; }
        public IEnumerable<Vacancy>? Vacancies { get; set; }
        ///TODO:Elaqeni belke deyisidim
    }
}
