using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic1:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
