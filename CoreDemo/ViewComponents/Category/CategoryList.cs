using BusinessLayer.Concrete;
using DataAccessLayer.EntityFrameworks;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Category
{
	public class CategoryList:ViewComponent
	{
		CategoryManager categoryManager = new CategoryManager(new EFCategoryRepository());
		public IViewComponentResult Invoke()
		{
			var values = categoryManager.GetAll();
			return View(values);
		}
	}
}
