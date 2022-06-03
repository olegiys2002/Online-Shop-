using Microsoft.AspNetCore.Identity;
using Shop.Application.DTO;
using Shop.Core.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.IServices
{
    public interface IUserService
    {
        Task<IdentityResult> AddToRoleAsync(ApplicationUserDTO applicationUserDTO,string role);
        Task<IdentityResult> CreateAsync(ApplicationUserDTO applicationUserDTO);
        Task<bool> DeleteUser(string id);
        void UpdateUser(ApplicationUser user);
        List<ApplicationUserDTO> GetAllUsers();
        Task<ApplicationUser> GetUserAsync(string id);
        Task<ApplicationUser> GetCurrentUserAsync();
        Task<int> SaveChangesAsync();
    }
}
