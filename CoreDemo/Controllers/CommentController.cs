using BusinessLayer.Concrete;
using DataAccessLayer.EntityFrameworks;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
	public class CommentController : Controller
	{
		CommentManager commentManager = new CommentManager(new EFCommentRepository());
		public IActionResult Index()
		{
			return View();
		}

		public PartialViewResult PartialViewComment()
		{
			return PartialView();
		}

		public PartialViewResult CommentListByBlog(int id)
		{
			var values=commentManager.GetListId(id);

			return PartialView(values);
		}
	}
}
