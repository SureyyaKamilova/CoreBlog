using BusinessLayer.Concrete;
using DataAccessLayer.EntityFrameworks;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;

namespace CoreDemo.Controllers
{
	
	public class ContactController : Controller
	{
		ContactManager contactManager = new ContactManager(new EFContactRepository());
		
		[HttpGet]
		public IActionResult Contact()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Contact(Contact contact)
		{
			contact.ContactDate = DateTime.Parse(DateTime.Now.ToShortDateString());
			contact.ContactStatus = true;
			contactManager.ContactAdd(contact);
			return RedirectToAction("Index", "Blog");
		}
	}
}
