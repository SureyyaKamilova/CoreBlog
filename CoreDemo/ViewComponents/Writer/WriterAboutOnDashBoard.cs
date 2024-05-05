using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFrameworks;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CoreDemo.ViewComponents.Writer
{
    public class WriterAboutOnDashBoard:ViewComponent
    {
        WriterManager writerManager = new WriterManager
                             (new EFWriterRepository());

        Context context = new Context();
        public IViewComponentResult Invoke()
        {
            var userMail = User.Identity.Name;
            var writerId = context.Writers.Where(x => x.WriterMail == userMail)
                                    .Select(y => y.WriterId ).FirstOrDefault();

            var values = writerManager.GetWriterById(writerId);
            return View(values);
        }

    }
}
