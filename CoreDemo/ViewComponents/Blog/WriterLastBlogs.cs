﻿using BusinessLayer.Concrete;
using DataAccessLayer.EntityFrameworks;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Blog
{
	public class WriterLastBlogs:ViewComponent
	{
		BlogManager blogManager = new BlogManager(new EFBlogRepository());

		public IViewComponentResult Invoke()
		{
			var values = blogManager.GetBlogListByWriter(1);
			return View(values);
		}
	}
}
