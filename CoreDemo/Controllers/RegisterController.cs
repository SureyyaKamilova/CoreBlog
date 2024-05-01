using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFrameworks;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
	public class RegisterController : Controller
	{
	    WriterManager writerManager = new WriterManager(new EFWriterRepository());
		
		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Index(Writer writer)
		{
			WriterValidation writerValidations=new WriterValidation();
			ValidationResult validationResult= writerValidations.Validate(writer);

			if(validationResult.IsValid)
			{
                writer.WriterStatus = true;
                writer.WriterAbout = "Writer About";
                writerManager.TAdd(writer);

                return RedirectToAction("Index", "Blog");
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
