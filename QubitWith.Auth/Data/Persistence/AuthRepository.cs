using Microsoft.AspNetCore.Identity;
using QubitWith.Auth.Data.Persistence.Contracts;

namespace QubitWith.Auth.Data.Persistence
{
    public class AuthRepository : IAuthRepository
    {
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AuthRepository(SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
