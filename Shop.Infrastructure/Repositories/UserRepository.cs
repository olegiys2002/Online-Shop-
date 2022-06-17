using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Shop.Core.IRepositories;
using Shop.Domain.Models.User;
using Shop.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        ApplicationDbContext _applicationDbContext;
        

        public UserRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public void AddUser(ApplicationUser user)
        {
 
            _applicationDbContext.Users.Add(user);
        }

        public async Task DeleteUser(string id)
        {
            ApplicationUser user = await _applicationDbContext.Users.FindAsync(id);
            _applicationDbContext.Users.Remove(user);
        }

        public async Task<ApplicationUser> GetUserAsync(string id)
        {
            var user = await _applicationDbContext.Users.SingleAsync(us => us.Id == id);
            return user;
        }

        public async Task<ApplicationUser> FindByNameAsync(string name)
        {
            var user = await _applicationDbContext.Users.SingleAsync(us => us.UserName == name);
            return user;
        }

        public List<ApplicationUser> GetAllUsers()
        {
            return _applicationDbContext.Users.ToList();
        }

 

        public void UpdateUser(ApplicationUser user)
        {
            _applicationDbContext.Users.Update(user);
        }
    }
}
