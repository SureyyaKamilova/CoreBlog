using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using CoreDemo.Models;
using DataAccessLayer.EntityFrameworks;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;

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

		[AllowAnonymous]
		[HttpGet]
		public IActionResult WriterAdd()
		{
			return View();
		}

		[AllowAnonymous]
		[HttpPost]
		public IActionResult WriterAdd(AddProfileImage addProfileImage)
		{
			Writer writer = new Writer();

			if (addProfileImage.WriterImage != null)
			{
				var extension = Path.GetExtension(addProfileImage.WriterImage.FileName);
				var newImageName = Guid.NewGuid() + extension;
				var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/CoreBlogTema/WriterImageFiles/", newImageName);
				var stream = new FileStream(location, FileMode.Create);
				
				addProfileImage.WriterImage.CopyTo(stream);
				writer.WriterImage = newImageName;
            }

            writer.WriterName = addProfileImage.WriterName;
            writer.WriterMail = addProfileImage.WriterMail;
			writer.WriterPassword = addProfileImage.WriterPassword;
			writer.WriterStatus = true;
			writer.WriterAbout=addProfileImage.WriterAbout;

			writerManager.TAdd(writer);
			return RedirectToAction("Index", "DashBoard");
		}

    }

}
