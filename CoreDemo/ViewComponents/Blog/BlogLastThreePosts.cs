using BusinessLayer.Concrete;
using DataAccessLayer.EntityFrameworks;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Blog
{
	public class BlogLastThreePosts:ViewComponent
	{
		BlogManager blogManager = new BlogManager(new EFBlogRepository());

		public IViewComponentResult Invoke()
		{
			var values = blogManager.GetLastThreeBlog();
			return View(values);
		}
	}
}
