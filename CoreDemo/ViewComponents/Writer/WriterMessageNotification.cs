using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFrameworks;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CoreDemo.ViewComponents.Writer
{
    public class WriterMessageNotification:ViewComponent
    {
        Message2Manager message2Manager = new Message2Manager(new EFMessage2Repository());
        Context context = new Context();
        public IViewComponentResult Invoke()
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
    }
}
