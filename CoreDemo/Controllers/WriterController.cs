using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFrameworks;
using EntityLayer.Concrete;
using FluentValidation.Results;
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
		[HttpGet]
		public IActionResult WriterEditProfile()
		{
			var writerValues = writerManager.GetById(1);
			return View(writerValues);
		}

		[AllowAnonymous]
		[HttpPost]
        public IActionResult WriterEditProfile(Writer writer)
        {
			WriterValidation writerValidation = new WriterValidation();
			ValidationResult validationResult = writerValidation.Validate(writer);

            if (validationResult.IsValid)
			{
				writerManager.TUpdate(writer);
				return RedirectToAction("Index","DashBoard");
			}
			else
			{
				foreach(var item in validationResult.Errors)
				{
					ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
				}
			}

			return View();
		}   



    }

}
