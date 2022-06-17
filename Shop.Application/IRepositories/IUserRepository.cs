using Shop.Domain.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Core.IRepositories
{
    public interface IUserRepository
    {
        void AddUser(ApplicationUser user);
        Task DeleteUser(string id);
        void UpdateUser(ApplicationUser user);
        List<ApplicationUser> GetAllUsers();
        Task<ApplicationUser> GetUserAsync(string id);
        Task<ApplicationUser> FindByNameAsync(string name);


    }
}
