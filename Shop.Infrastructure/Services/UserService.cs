
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Shop.Application.DTO;
using Shop.Application.IServices;
using Shop.Core.Models.User;

namespace Shop.Infrastructure.Services
{
    public class UserService : IUserService
    {
        IHttpContextAccessor _contextAccessor;
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<ApplicationUser> _userManager;
        public UserService(IUnitOfWork unitOfWork,UserManager<ApplicationUser> userManager,IHttpContextAccessor contextAccessor)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _contextAccessor = contextAccessor;
        }

        public async Task<IdentityResult> AddToRoleAsync(ApplicationUserDTO applicationUserDTO,string role)
        {

            var user  = await _unitOfWork.UserRepository.FindByNameAsync(applicationUserDTO.Name);
            var result = await  _userManager.AddToRoleAsync(user, role);
            return result;
        }

        public async Task<IdentityResult> CreateAsync(ApplicationUserDTO user)
        {
            ApplicationUser applicationUser = new ApplicationUser()
            {
                UserName = user.Name,
                Email = user.Email
            };
           return await _userManager.CreateAsync(applicationUser,user.Password);
        }

        public async Task<bool> DeleteUser(string id)
        {
            ApplicationUser user = await _userManager.FindByIdAsync(id);
            bool isUserAdmin = await _userManager.IsInRoleAsync(user, "admin");

            if (isUserAdmin)
            {
                return false; 
            }
            if (user != null)
            {
                await _userManager.DeleteAsync(user);
            }

            return true;

        }

        public List<ApplicationUserDTO> GetAllUsers()
        {
            List<ApplicationUserDTO> userDTOs = new();
            List<ApplicationUser> users = _userManager.Users.ToList();
            foreach (var user in users)
            {
                userDTOs.Add(new ApplicationUserDTO() 
                { 
                    Id = user.Id,
                    Email = user.Email,
                    Name = user.UserName

                });

            }
            return userDTOs;
        }

        public async Task<ApplicationUser> GetCurrentUserAsync()
        {
            var currentUserId = _userManager.GetUserId(_contextAccessor.HttpContext.User);
            var user = await _unitOfWork.UserRepository.GetUserAsync(currentUserId);

            return user;
        }

        public async Task<ApplicationUser> GetUserAsync(string id)
        {
            var applicationUser = await _unitOfWork.UserRepository.GetUserAsync(id);
            return await _unitOfWork.UserRepository.GetUserAsync(id);
        }

        public Task<int> SaveChangesAsync()
        {
            return _unitOfWork.Complete();
        }

        public void UpdateUser(ApplicationUser user)
        {
            _unitOfWork.UserRepository.UpdateUser(user);
        }
    }
}
