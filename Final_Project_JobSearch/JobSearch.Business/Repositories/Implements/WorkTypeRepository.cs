using JobSearch.Business.Repositories.Interfaces;
using JobSearch.Core.Entities;
using JobSearch.DAL.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearch.Business.Repositories.Implements
{
    public class WorkTypeRepository : GenericRepository<WorkType>, IWorkTypeRepository
    {
        public WorkTypeRepository(JobSearchContext context) : base(context)
        {
        }
    }
}
