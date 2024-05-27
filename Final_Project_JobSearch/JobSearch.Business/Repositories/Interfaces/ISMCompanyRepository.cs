using JobSearch.Core.Entities;

namespace JobSearch.Business.Repositories.Interfaces
{
    public interface ISMCompanyRepository:IGenericRepository<SocialMediaCompany>
    {
        Task AddSM(SocialMediaCompany data);

    }
}
