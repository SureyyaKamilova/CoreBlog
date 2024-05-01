using BusinessLayer.Concrete;
using DataAccessLayer.EntityFrameworks;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Writer
{
    public class WriterAboutOnDashBoard:ViewComponent
    {
        WriterManager writerManager = new WriterManager
                             (new EFWriterRepository());

        public IViewComponentResult Invoke()
        {
            var values = writerManager.GetWriterById(1);
            return View(values);
        }

    }
}
