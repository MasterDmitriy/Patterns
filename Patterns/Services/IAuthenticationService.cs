using DAL.Models;

namespace Patterns.Services
{
    public interface IAuthenticationService
    {
        User GetUser();
    }
}