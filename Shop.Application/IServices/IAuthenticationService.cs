using Microsoft.AspNetCore.Identity;
using Shop.Application.DTO;


namespace Shop.Application.IServices
{
    public interface IAuthenticationService
    {
        public Task SignInAsync(ApplicationUserDTO applicationUser);
        public Task SignOutAsync();
        public Task<SignInResult> PasswordSignInAsync(string userName, string Password, bool persistant, bool lockoutEnable);
    }
}
