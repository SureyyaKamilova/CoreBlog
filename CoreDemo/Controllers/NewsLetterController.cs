using BusinessLayer.Concrete;
using DataAccessLayer.EntityFrameworks;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace CoreDemo.Controllers
{
	[AllowAnonymous]
	public class NewsLetterController : Controller
	{
		NewsLetterManager newsLetterManager = new NewsLetterManager(new EFNewsLetterRepository());
		[HttpGet]
		public IActionResult SubscribeMail()
		{
			return PartialView();
		}

		[HttpPost]
		public IActionResult SubscribeMail(NewsLetter newsLetter)
		{
			newsLetter.MailStatus = true;
			newsLetterManager.AddNewsLetter(newsLetter);

			return PartialView();

		}
	}
}
