using JobSearch.Core.Entities.Common;
using Microsoft.AspNetCore.Http;

namespace JobSearch.Business.Exceptions.CommonExceptions
{
    public class AlreadyExistException<T> : Exception, IBaseException where T : BaseEntity
    {
        public AlreadyExistException()
        {
            ErrorMessage = typeof(T).Name + " Already exist";
        }

        public AlreadyExistException(string? message)
        {
            ErrorMessage = message;
        }

        public int StatusCode => StatusCodes.Status409Conflict;

        public string ErrorMessage { get; set; }
    }
}
