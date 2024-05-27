using JobSearch.Business.Repositories.Interfaces;
using JobSearch.Core.Entities;
using JobSearch.DAL.Contexts;

namespace JobSearch.Business.Repositories.Implements
{
    public class CompanyRepository : GenericRepository<Company>, ICompanyRepository
    {
        public CompanyRepository(JobSearchContext context) : base(context){}
    }
}
