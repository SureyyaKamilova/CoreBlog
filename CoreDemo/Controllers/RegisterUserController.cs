using CoreDemo.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
    [AllowAnonymous]
    public class RegisterUserController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        public RegisterUserController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserSignUpViewModel parameters)
        { 
            if (ModelState.IsValid)
            {
                AppUser appUser = new AppUser()
                {
                    Email=parameters.Mail,
                    UserName=parameters.UserName,
                    FullName=parameters.FullName, 

                };
                    
                var result = await _userManager.CreateAsync(appUser, parameters.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "LogIn");
                }
                else
                {
                    foreach(var user in result.Errors)
                    {
                        ModelState.AddModelError(" ", user.Description);
                    }
                }
            }
            return View(parameters);
        }

    }
}
