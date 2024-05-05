using BusinessLayer.Concrete;
using DataAccessLayer.EntityFrameworks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace CoreDemo.Controllers
{
    public class MessageController : Controller
    {
        Message2Manager message2Manager = new Message2Manager(new EFMessage2Repository());

        [AllowAnonymous]
        public IActionResult Inbox()
        {
            int id = 2;
            var values = message2Manager.GetInboxListByWriter(id);
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
