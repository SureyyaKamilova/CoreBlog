using CoreDemo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CoreDemo.ViewComponents
{
	public class CommentList : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			var commentValues = new List<UserComment>
			{
				new UserComment
				{
					Id = 1,
					UserName = "admin"
				},
				new UserComment
				{
					Id = 2,
					UserName = "Surayya"
				},
				new UserComment
				{
					Id = 3,
					UserName = "Kanan"
				}
			};

			return View(commentValues);
		}
	}
}

