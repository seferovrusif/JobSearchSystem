using JobSearch.Business.Repositories.Interfaces;
using JobSearch.Core.Entities;
using JobSearch.DAL.Contexts;

namespace JobSearch.Business.Repositories.Implements
{
    public class SalaryRepository : GenericRepository<Salary>, ISalaryRepository
    {
        public SalaryRepository(JobSearchContext context) : base(context)
        {
        }
    }
}
