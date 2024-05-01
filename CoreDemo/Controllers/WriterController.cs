using BusinessLayer.Concrete;
using DataAccessLayer.EntityFrameworks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
	public class WriterController : Controller
	{
		WriterManager writerManager = new WriterManager(new EFWriterRepository());		public IActionResult Index()
		{
			return View();
		}

		public IActionResult WriterProfile()
		{
			return View();
		}
		
		public IActionResult WriterMail()
		{
			return View();
		}

		[AllowAnonymous]
		public IActionResult Test()
		{
			return View();
		}

		[AllowAnonymous]
		public PartialViewResult WriterNavBarPartial()
		{
			return PartialView();
		}

        [AllowAnonymous]
        public PartialViewResult WriterHeaderPartial()
        {
            return PartialView();
        }

		[AllowAnonymous]
		public IActionResult WriterEditProfile()
		{
			var writerValues = writerManager.GetById(1);
			return View(writerValues);
		}




    }

}
