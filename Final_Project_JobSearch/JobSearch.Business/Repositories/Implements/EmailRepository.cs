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
    public class EmailRepository : GenericRepository<Email>, IEmailRepository
    {
        public EmailRepository(JobSearchContext context) : base(context)
        {
        }
        public int GetIdFromEmail(string Email)
        {

            var data = Table.SingleOrDefault(x => x.EmailAddress == Email);
            return data == null ? 0 : data.Id;
        }
    }
}
