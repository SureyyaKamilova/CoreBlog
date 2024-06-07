using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFrameworks;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
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

        [HttpGet]
        public IActionResult ComposeMessage()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ComposeMessage(Message2 message)
        {
            var userName = User.Identity.Name;
            var userMail = context.Users.Where(x => x.UserName == userName)
                                     .Select(y => y.Email)
                                     .FirstOrDefault();
            var writerId = context.Writers.Where(x => x.WriterMail == userMail)
                                        .Select(y => y.WriterId)
                                        .FirstOrDefault();

            message.SenderId = writerId;
            message.ReceiverId = 2;
            message.MessageDate=Convert.ToDateTime(DateTime.Now.ToShortDateString());
            message.MessageStatus = true;

            message2Manager.TAdd(message);
            return RedirectToAction("SendBox");
        }
    }

}
