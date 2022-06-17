using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Shop.Core.DTO;
using Shop.Core.IServices;
using Shop.Domain.Models.User;
using IAuthenticationService = Shop.Core.IServices.IAuthenticationService;

namespace Shop.Core.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IUnitOfWork _unitOfWork;
        private IHttpContextAccessor _contextAccessor;
        public AuthenticationService(SignInManager<ApplicationUser> signInManager, IUnitOfWork unitOfWork,IHttpContextAccessor httpContextAccessor)
        {
            _signInManager = signInManager;
            _unitOfWork = unitOfWork;
            _contextAccessor = httpContextAccessor;
        }

        public async Task<SignInResult> PasswordSignInAsync(string userName, string password, bool persistant, bool lockoutEnable)
        {
            _contextAccessor.HttpContext.Session.Clear();
            var result = await _signInManager.PasswordSignInAsync(userName, password, persistant, lockoutEnable);
           return result;
        }

        public async Task SignInAsync(ApplicationUserDTO applicationUserDTO)
        {
            _contextAccessor.HttpContext.Session.Clear();
            ApplicationUser user = await _unitOfWork.UserRepository.FindByNameAsync(applicationUserDTO.Name);
            string password = applicationUserDTO.Password;
            await _signInManager.PasswordSignInAsync(user, password, false, false);
            
        }

        public async Task SignOutAsync()
        {
            _contextAccessor.HttpContext.Session.Clear();
            await _signInManager.SignOutAsync();
        }
    }
}
