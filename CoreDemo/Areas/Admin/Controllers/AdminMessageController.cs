using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFrameworks;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminMessageController : Controller
    {
        Message2Manager message2Manager = new Message2Manager(new EFMessage2Repository());
        Context context = new Context();
        public IActionResult InBox()
        {
            var userName = User.Identity.Name;


            var userMail = context.Users.Where(x => x.UserName == userName)
                                      .Select(y => y.Email)
                                      .FirstOrDefault();
            var writerId = context.Writers.Where(x => x.WriterMail == userMail)
                                        .Select(y => y.WriterId)
                                        .FirstOrDefault();
            var values = message2Manager.GetInboxListByWriter(writerId);
            return View(values);
        }

        public IActionResult SendBox()
        {
            var userName = User.Identity.Name;


            var userMail = context.Users.Where(x => x.UserName == userName)
                                      .Select(y => y.Email)
                                      .FirstOrDefault();
            var writerId = context.Writers.Where(x => x.WriterMail == userMail)
                                        .Select(y => y.WriterId)
                                        .FirstOrDefault();
            var values = message2Manager.GetSendBoxListByWriter(writerId);
            return View(values);
        }

        public IActionResult ComposeMessage()
        {
            return View();
        }
    }
}
