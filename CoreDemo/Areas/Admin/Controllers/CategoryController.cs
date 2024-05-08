using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFrameworks;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using X.PagedList;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        CategoryManager categoryManager = new CategoryManager(new EFCategoryRepository());
        Context context =new Context();
        public IActionResult Index(int page=1)
        {
            var values = categoryManager.GetList().ToPagedList(page, 3);
            return View(values);
        }

        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCategory(Category category)
        {
            CategoryValidation categoryValidation=new CategoryValidation();
            ValidationResult validationResult=categoryValidation.Validate(category);

            if (validationResult.IsValid)
            {
                category.CategoryStatus = true;
                categoryManager.TAdd(category);

                return RedirectToAction("Index", "Category");

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

        public IActionResult CategoryDelete(int id)
        {
            var categoryValue=categoryManager.GetById(id);
            categoryManager.TDelete(categoryValue);
            return RedirectToAction("Index");
        }
    }
}
