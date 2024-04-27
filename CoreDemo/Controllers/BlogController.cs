using BusinessLayer.Concrete;
using DataAccessLayer.EntityFrameworks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
    [AllowAnonymous]
    public class BlogController : Controller
    {
        BlogManager blogManager = new BlogManager(new EFBlogRepository());
        public IActionResult Index()
        {
            var values=blogManager.GetBlogListCategory();
            return View(values);
        }

        public IActionResult BlogReadAll(int id)
        {
            ViewBag.Id = id;
            var values=blogManager.GetBlogById(id);

            return View(values);
        }

        public IActionResult BlogListByWriter()
        {
            var values=blogManager.GetBlogListByWriter(1);
            return View(values);
        }

    }
}
