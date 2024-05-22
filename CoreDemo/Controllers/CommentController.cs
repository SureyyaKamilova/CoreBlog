using BusinessLayer.Concrete;
using DataAccessLayer.EntityFrameworks;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CoreDemo.Controllers
{
	[AllowAnonymous]
	public class CommentController : Controller
	{
		CommentManager commentManager = new CommentManager(new EFCommentRepository());
		public IActionResult Index()
		{
			return View();
		}
		[HttpGet]
		public PartialViewResult PartialViewComment()
		{
			return PartialView();
		}
		[HttpPost]
		public IActionResult PartialViewComment(Comment comment)
		{
			comment.CommentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
			comment.CommentStatus = true;

			comment.BlogId = 3;
			commentManager.CommentAdd(comment);

			return PartialView();
		}

		public PartialViewResult CommentListByBlog(int id)
		{
			var values=commentManager.GetListId(id);

			return PartialView(values);
		}
	}
}
