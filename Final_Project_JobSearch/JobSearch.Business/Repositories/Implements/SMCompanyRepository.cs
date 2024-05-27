using JobSearch.Business.DTOs.SMCompanyDTOs;
using JobSearch.Business.Repositories.Interfaces;
using JobSearch.Core.Entities;
using JobSearch.DAL.Contexts;

namespace JobSearch.Business.Repositories.Implements
{
    public class SMCompanyRepository : GenericRepository<SocialMediaCompany>, ISMCompanyRepository
    {
        public SMCompanyRepository(JobSearchContext context) : base(context)
        {
        }
        public async Task AddSM (SocialMediaCompany dto)
        {
            await Table.AddAsync(dto);
        }
    }
}
