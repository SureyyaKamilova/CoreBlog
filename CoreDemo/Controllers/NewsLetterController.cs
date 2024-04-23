using BusinessLayer.Concrete;
using DataAccessLayer.EntityFrameworks;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace CoreDemo.Controllers
{
	public class NewsLetterController : Controller
	{
		NewsLetterManager newsLetterManager = new NewsLetterManager(new EFNewsLetterRepository());
		[HttpGet]
		public PartialViewResult SubscribeMail()
		{
			return PartialView();
		}

		[HttpPost]
		public PartialViewResult SubscribeMail(NewsLetter newsLetter)
		{
			newsLetter.MailStatus = true;
			newsLetterManager.AddNewsLetter(newsLetter);

			return PartialView(RedirectToAction("BlogReadAll"));

		}
	}
}
