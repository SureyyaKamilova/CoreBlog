﻿using BusinessLayer.Concrete;
using DataAccessLayer.EntityFrameworks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
    public class NotificationController : Controller
    {
        NotificationManager notificationManager = new NotificationManager(new EFNotificationRepository());
        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult AllNotification()
        {
            var values = notificationManager.GetList();
            return View(values);
        }
    }
}
 