using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CoreDemo.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic4:ViewComponent
    {
        Context context = new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.value1 = context.Admins.Where(x => x.AdminId == 1).Select(y => y.Name)
                             .FirstOrDefault();
            ViewBag.value2 = context.Admins.Where(x => x.AdminId == 1).Select(y => y.ImageUrl)
                             .FirstOrDefault();
            ViewBag.value3 = context.Admins.Where(x => x.AdminId == 1).Select(y => y.ShortDescription)
                             .FirstOrDefault();
            return View();
        }
    }
}
