using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFrameworks;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoreDemo.Controllers
{
    public class MessageController : Controller
    {
        Message2Manager message2Manager = new Message2Manager(new EFMessage2Repository());
        Context context = new Context();
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

        public IActionResult MessageDetails(int id)
        {
            var messageValue = message2Manager.GetById(id);
           
            return View(messageValue);
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
        public IActionResult SendMessage()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendMessage(Message2 message)
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
            message.MessageStatus = true;
            message.MessageDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());

            message2Manager.TAdd(message);
            return RedirectToAction("InBox");

        }
    }
}
