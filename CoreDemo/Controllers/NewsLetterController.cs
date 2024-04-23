using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
	public class NewsLetterController : Controller
	{
		[HttpGet]
		public PartialViewResult SubscribeMail()
		{
			return PartialView();
		}

		[HttpPost]
		public PartialViewResult SubscribeMail(NewsLetter newsLetter)
		{
			return PartialView();
		}
	}
}
