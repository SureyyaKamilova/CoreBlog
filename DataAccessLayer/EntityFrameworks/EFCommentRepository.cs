﻿using DataAccessLayer.Concrete;
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
    public class EFCommentRepository : GenericRepository<Comment>, IComment
    {
        public List<Comment> GetListWithBlog()
        {
            using(var context=new Context())
            {
                return context.Comments.Include(x=>x.Blog)
                               .ToList();
            }
        }
    }
}
