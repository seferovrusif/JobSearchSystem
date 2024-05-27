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
    public class SMJobSeekerRepository : GenericRepository<SocialMediaJobSeeker>, ISMJobSeekerRepository
    {
        public SMJobSeekerRepository(JobSearchContext context) : base(context)
        {
        }
        public async Task AddSM(SocialMediaJobSeeker dto)
        {
            await Table.AddAsync(dto);
        }
    }
}
