﻿using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
	public interface ICommentService
	{
		void CommentAdd(Comment comment);
		void CommentDelete(Comment comment);
		void CommentUpdate(Comment comment);
		List<Comment> GetListId(int id);
		Comment GetById(int id);
	}
}