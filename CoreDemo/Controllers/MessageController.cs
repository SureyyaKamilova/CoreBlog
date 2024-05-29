using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFrameworks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace CoreDemo.Controllers
{
    public class MessageController : Controller
    {
        Message2Manager message2Manager = new Message2Manager(new EFMessage2Repository());
        Context context = new Context();
        [AllowAnonymous]
        public IActionResult Inbox()
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
        [AllowAnonymous]
        public IActionResult MessageDetails(int id)
        {
            var messageValue = message2Manager.GetById(id);
           
            return View(messageValue);
        }
    }
}
