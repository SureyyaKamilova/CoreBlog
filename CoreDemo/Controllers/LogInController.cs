using CoreDemo.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
    [AllowAnonymous]
    public class LogInController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;

        public LogInController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task< IActionResult> Index(UserSignInViewModel parameter)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(parameter.username, parameter.password, false, true);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "DashBoard");
                }
                else
                {
                    return RedirectToAction("Index","LogIn");
                }
            }
            return View();
            
        }

        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Index", "LogIn");
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
