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
	public class BlogManager : IBlogService
	{
		private readonly IBlog _blog;
		public BlogManager(IBlog blog)
		{
			_blog = blog;
		}

		public void BlogAdd(Blog blog)
		{
			_blog.Insert(blog);
		}

		public void BlogDelete(Blog blog)
		{
			_blog.Delete(blog);
		}

		public void BlogUpdate(Blog blog)
		{
			_blog.Update(blog);
		}

		public List<Blog> GetAll()
		{

			return _blog.GetAll();
		}

		public List<Blog> GetBlogListCategory()
		{
			return _blog.GetListCategory();
		}

		public Blog GetById(int id)
		{

			return _blog.GetById(id);
		}
	}
}
