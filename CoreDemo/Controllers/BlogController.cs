using BusinessLayer.Concrete;
using DataAccessLayer.EntityFrameworks;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
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
            var values=blogManager.GetBlogById(id);

            return View(values);
        }
    }
}
