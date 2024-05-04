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
    public class EFMessage2Repository : GenericRepository<Message2>, IMessage2
    {
        public List<Message2> GetListWithMessageByWriter(int id)
        {
            using(var context=new Context())
            {
                return context.Messages2.Include(x=>x.SenderUser)
                       .Where(x=>x.ReceiverId==id).ToList();
            }
        }
    }
}
