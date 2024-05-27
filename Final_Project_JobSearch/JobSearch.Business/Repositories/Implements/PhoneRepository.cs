using JobSearch.Business.Repositories.Interfaces;
using JobSearch.Core.Entities;
using JobSearch.DAL.Contexts;

namespace JobSearch.Business.Repositories.Implements
{
    public class PhoneRepository : GenericRepository<Phone>, IPhoneRepository
    {
        public PhoneRepository(JobSearchContext context) : base(context)
        {
        }

        public int GetIdFromNumber(string number)
        {

            var data = Table.SingleOrDefault(x => x.Number == number);
            return data == null ? 0 : data.Id;
        }

    }
}
