using JobSearch.Core.Entities.Common;
using Microsoft.AspNetCore.Http;

namespace JobSearch.Business.Exceptions.CommonExceptions
{
    public class NotFoundException<T> : Exception, IBaseException where T : BaseEntity
    {
        public NotFoundException()
        {
            ErrorMessage = typeof(T).Name + " Not found";
        }

        public NotFoundException(string? message)
        {
            ErrorMessage = message;
        }

        public int StatusCode => StatusCodes.Status404NotFound;

        public string ErrorMessage { get; set; }
    }
}
