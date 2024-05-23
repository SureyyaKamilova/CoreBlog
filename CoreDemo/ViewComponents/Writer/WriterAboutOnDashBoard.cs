using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFrameworks;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.ViewComponents.Writer
{
    public class WriterAboutOnDashBoard:ViewComponent
    {
        WriterManager writerManager = new WriterManager
                             (new EFWriterRepository());

       
        Context context = new Context();
        public IViewComponentResult Invoke()
        {
            var userName=User.Identity.Name;
            ViewBag.name = userName;

            var userMail = context.Users.Where(x => x.UserName == userName)
                                .Select(y => y.Email).FirstOrDefault();

            var writerId=context.Writers.Where(x=>x.WriterMail==userMail)
                                .Select(y=>y.WriterId).FirstOrDefault();
            var values = writerManager.GetWriterById(writerId);
            return View(values);
        }

    }
}
