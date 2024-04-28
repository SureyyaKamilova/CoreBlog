using DataAccessLayer.Concrete;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFrameworks
{
	public class EFBlogRepository : GenericRepository<Blog>, IBlog
	{
		public List<Blog> GetListCategory()
		{
			using (var context=new Context())
			{
				return context.Blogs.Include(x=>x.Category).ToList();
			}
		}

        public List<Blog> GetListCategoryByWriter(int id)
        {
            using(var context=new Context())
			{
				return context.Blogs.Include(x => x.Category)
					                .Where(x => x.WriterId == id).ToList();
			}
        }
    }
}
