﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.DTO;
using Shop.Application.IServices;
using КурсовойИнтернетМагазин.ViewModels.UserViewModel;

namespace КурсовойИнтернетМагазин.Controllers
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
