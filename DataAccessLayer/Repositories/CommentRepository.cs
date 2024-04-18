using DataAccessLayer.Concrete;
using DataAccessLayer.Interfaces;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class CommentRepository : IGeneric<Comment>
    {
        Context context = new Context();
        public void Delete(Comment comment)
        {
            context.Remove(comment);
            context.SaveChanges();
        }

        public List<Comment> GetAll()
        {
            return context.Comments.ToList();
        }

        public Comment GetById(int id)
        {
            return context.Comments.Find(id);
        }

        public void Insert(Comment comment)
        {
            context.Add(comment);
            context.SaveChanges();
        }

        public void Update(Comment comment)
        {
            context.Update(comment);
            context.SaveChanges();
        }
    }
}
