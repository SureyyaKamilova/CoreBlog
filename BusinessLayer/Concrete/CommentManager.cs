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

		public List<Comment> GetListId(int id)
		{
			return _comment.GetList(x =>x.BlogId== id);
		}


        public List<Comment> GetCommentWithBlog()
        {
			return _comment.GetListWithBlog();
        }
    }
}
