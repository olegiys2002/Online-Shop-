using Microsoft.AspNetCore.Mvc;
using Shop.Core.DTO;
using Shop.Core.IServices;
using Shop.Domain.Models.User;
using ShopUI.Models;

namespace ShopUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        private readonly IAuthenticationService _authenticationService;
        public AccountController(IUserService userService,IAuthenticationService authenticationService)
        {
            _userService = userService;
            _authenticationService = authenticationService;       
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
            
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel customer)
        {
            if (ModelState.IsValid)
            {
                ApplicationUserDTO applicationUserDTO = new ApplicationUserDTO()
                {
                    Name = customer.Name,
                    Email= customer.Email,
                    Password = customer.Password,

                };

                var result = await _userService.CreateAsync(applicationUserDTO);
                
                if (result.Succeeded)
                {
                    await _authenticationService.SignInAsync(applicationUserDTO);
                    var result2 = await _userService.AddToRoleAsync(applicationUserDTO,"customer");
                    if (result2.Succeeded)
                    {
                        return RedirectToAction("HomePage", "Home");
                    }
                   
                }
                else
                {
                    ModelState.AddModelError("", "Данные некорректны ,используйте цифры и английский");
                }

            }

            return View(customer);
        }

        [HttpGet]

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel customer)
        {

            if (ModelState.IsValid)
            {
                var result = await _authenticationService.PasswordSignInAsync(customer.Name, customer.Password, false, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("HomePage", "Home");
                }
                else
                {
                    ModelState.AddModelError("","Логин или пароль некорректны");
                }

            }
            return View(customer);
        }
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            
            await _authenticationService.SignOutAsync();
            return RedirectToAction("HomePage", "Home");
        }
    }
}
