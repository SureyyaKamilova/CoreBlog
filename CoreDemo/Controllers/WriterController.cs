using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using CoreDemo.Models;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFrameworks;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;

namespace CoreDemo.Controllers
{
    public class WriterController : Controller
    {
        WriterManager writerManager = new WriterManager(new EFWriterRepository());
        Context context = new Context();

        private readonly UserManager<AppUser> _userManager;

        public WriterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [Authorize]
        public IActionResult Index()
        {
            var userMail = User.Identity.Name;
            ViewBag.v = userMail;

            var writerName = context.Writers
                .Where(x => x.WriterMail == userMail)
                .Select(y => y.WriterName)
                .FirstOrDefault();
            ViewBag.v2 = writerName;
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

            UserManager userManager = new UserManager(new EFUserRepository());

            var userName = User.Identity.Name;
            var userMail = context.Users.Where(x => x.UserName == userName).Select(y => y.Email)
                                .FirstOrDefault();
            //var values = await _userManager.FindByNameAsync(userName);
            var id = context.Users.Where(x => x.Email == userMail)
                .Select(y => y.Id).FirstOrDefault();

            var values = userManager.GetById(id);

            return View(values);

        }

        [HttpPost]
        public IActionResult WriterEditProfile(Writer writer)
        {
            WriterValidation writerValidation = new WriterValidation();
            ValidationResult validationResult = writerValidation.Validate(writer);

            if (validationResult.IsValid)
            {
                writerManager.TUpdate(writer);
                return RedirectToAction("Index", "DashBoard");
            }
            else
            {
                foreach (var item in validationResult.Errors)
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
            writer.WriterAbout = addProfileImage.WriterAbout;

            writerManager.TAdd(writer);
            return RedirectToAction("Index", "DashBoard");
        }

    }

}
