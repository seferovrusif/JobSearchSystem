using Microsoft.AspNetCore.Http;

namespace JobSearch.Business.Exceptions.AppUser
{
    public class PasswordOrUserNameWrongException : Exception, IBaseException
    {
        public int StatusCode => StatusCodes.Status400BadRequest;
        public string ErrorMessage { get; set; }

        public PasswordOrUserNameWrongException()
        {
            ErrorMessage = "Username or password is wrong";
        }

        public PasswordOrUserNameWrongException(string? message)
        {
            ErrorMessage = message;
        }

    }
   
}
