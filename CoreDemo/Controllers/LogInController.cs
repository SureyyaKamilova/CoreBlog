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

        //      [HttpPost]
        //public async Task<IActionResult> Index(Writer writer)
        //{
        //	#region LogIn
        //	//Context context =new Context();
        //	//var dataValue = context.Writers.FirstOrDefault(x => x.WriterMail == writer.WriterMail &&
        //	//								x.WriterPassword == writer.WriterPassword);
        //	//if (dataValue != null)
        //	//{
        //	//	HttpContext.Session.SetString("username", writer.WriterMail);
        //	//	return RedirectToAction("Index", "Writer");
        //	//}
        //	//else
        //	//{
        //	//	return View();
        //	//}
        //	#endregion

        //	Context context = new Context();
        //	var dataValue=context.Writers.FirstOrDefault(x => x.WriterMail == writer.WriterMail &&
        //					             x.WriterPassword == writer.WriterPassword);

        //	if (dataValue != null)
        //	{
        //		var claims = new List<Claim>
        //		{
        //			new Claim(ClaimTypes.Name,writer.WriterMail)
        //		};

        //		var userIdentity = new ClaimsIdentity(claims, "a");
        //		ClaimsPrincipal principal=new ClaimsPrincipal(userIdentity);

        //		await HttpContext.SignInAsync(principal);
        //		return RedirectToAction("Index","DashBoard");
        //	}
        //	else
        //	{
        //		return View();
        //	}

        //}
    }
}
