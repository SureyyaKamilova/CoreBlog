using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CoreDemo.Controllers
{
    public class DashBoardController : Controller
    {
        public IActionResult Index()
        {
            Context context=new Context();
            var userName=User.Identity.Name;

            var userMail = context.Users.Where(x => x.UserName == userName)
                                .Select(y => y.Email).FirstOrDefault();
            var writerId=context.Writers.Where(x=>x.WriterMail==userMail)
                                 .Select(y => y.WriterId).FirstOrDefault();

            ViewBag.v1=context.Blogs.Count().ToString();
            
            ViewBag.category=context.Categories.Count().ToString() ;
            return View();
        }
    }
}
