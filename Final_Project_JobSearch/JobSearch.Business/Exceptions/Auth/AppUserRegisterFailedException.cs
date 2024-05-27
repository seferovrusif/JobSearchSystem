using Microsoft.AspNetCore.Http;

namespace JobSearch.Business.Exceptions.AppUser
{
    public class AppUserRegisterFailedException : Exception, IBaseException
    {

        public int StatusCode => StatusCodes.Status409Conflict;

        public string ErrorMessage { get; set; }
        public AppUserRegisterFailedException()
        {
                ErrorMessage = "Registration failed";
        }


        public AppUserRegisterFailedException(string? message)
        {
            ErrorMessage = message;

        }
    }
}
