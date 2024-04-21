using BusinessLayer.Interfaces;
using DataAccessLayer.Interfaces;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
	public class CommentManager : ICommentService
	{
		private readonly IComment _comment;
		public CommentManager(IComment comment)
		{
			_comment = comment;
		}

		public void CommentAdd(Comment comment)
		{
			_comment.Insert(comment);
		}

		public void CommentDelete(Comment comment)
		{
			_comment.Delete(comment);
		}

		public void CommentUpdate(Comment comment)
		{
			_comment.Update(comment);
		}

		public List<Comment> GetListId(int id)
		{
			return _comment.GetList(x =>x.BlogId== id);
		}

		public Comment GetById(int id)
		{
			return _comment.GetById(id);
		}
	}
}
