using DAL.Models;

namespace Patterns.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        public User GetUser()
        {
            return new User
            {
                Id = 1,
                Login = "Login",
                Password = "Password",
                Role = new Role
                {
                    Id = 1,
                    Type = RoleType.User
                },
                RoleId = 1
            };
        }
    }
}