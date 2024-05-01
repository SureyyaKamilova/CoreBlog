using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CoreDemo.Controllers
{
    public class DashBoardController : Controller
    {
        [AllowAnonymous]
        public IActionResult Index()
        {
            Context context=new Context();
            ViewBag.v1=context.Blogs.Count().ToString();
            ViewBag.yourblogs=context.Blogs.Where(x=>x.WriterId==1).Count().ToString();
            ViewBag.category=context.Categories.Count().ToString() ;
            return View();
        }
    }
}
