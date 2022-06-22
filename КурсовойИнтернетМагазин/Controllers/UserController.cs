using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.Domain.DTO;
using ShopUI.ViewModels.UserViewModel;
using Shop.Domain.IServices;

namespace ShopUI.Controllers
{
   [Authorize(Roles ="admin")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService; 
        }
        public IActionResult Users()
        {
            List<ApplicationUserDTO> applicationUsersDTO = _userService.GetAllUsers();
            ListOfUsersViewModel listOfUsersViewModel = new ListOfUsersViewModel()
            {
                UserDTO = applicationUsersDTO
            };
            return View(listOfUsersViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            if (ModelState.IsValid)
            {
                await _userService.DeleteUser(id);
                 return RedirectToAction("Users");
            }
            return View();
        }
    }
}
