using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFrameworks;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Xml.Linq;

namespace CoreDemo.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic1:ViewComponent
    {
        BlogManager blogManager = new BlogManager(new EFBlogRepository());
        Context context = new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.value1 = blogManager.GetList().Count;
            ViewBag.value2 = context.Contacts.Count();
            ViewBag.value3 = context.Comments.Count();

            string api = "21c2e4fee765d14f9168b8b876d1c221";
            string connection = "https://api.openweathermap.org/data/2.5/weather?q=Baku&mode=xml&lang=az&units=metric&appid="+api;
            XDocument document=XDocument.Load(connection);
            ViewBag.value4 = document.Descendants("temperature").ElementAt(0)
                .Attribute("value").Value;

            return View();
        }
    }
}
