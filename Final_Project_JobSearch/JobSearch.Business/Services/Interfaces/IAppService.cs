using JobSearch.Core.Entities;

namespace JobSearch.Business.Services.Interfaces
{
    public interface IAppService
    {
        public IEnumerable<string> GetAllRoles();
        public  Task ChangeRole(string userId,string role);
    }
}
