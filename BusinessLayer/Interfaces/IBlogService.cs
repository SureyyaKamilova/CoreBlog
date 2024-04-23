﻿using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
	public interface IBlogService
	{
		void BlogAdd(Blog blog);
		void BlogDelete(Blog blog);
		void BlogUpdate(Blog blog);
		List<Blog> GetAll();
		Blog GetById(int id);
		List<Blog> GetBlogListCategory();
		List<Blog> GetBlogListByWriter(int id);
	}
}
