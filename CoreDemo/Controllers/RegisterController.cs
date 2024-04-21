using BusinessLayer.Concrete;
using DataAccessLayer.EntityFrameworks;
using EntityLayer.Concrete;
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
			writer.WriterStatus = true;
			writer.WriterAbout = "Writer About";
			writerManager.WriterAdd(writer);

			return RedirectToAction("Index","Blog");
		}
	}
}
