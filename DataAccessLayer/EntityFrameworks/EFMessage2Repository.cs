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
        public List<Message2> GetInBoxWithMessageByWriter(int id)
        {
            using(var context=new Context())
            {
                return context.Messages2.Include(x=>x.SenderUser)
                       .Where(x=>x.ReceiverId==id).ToList();
            }
        }

        public List<Message2> GetSendBoxWithMessageByWriter(int id)
        {
            using (var context = new Context())
            {
                return context.Messages2.Include(x => x.ReceiverUser)
                       .Where(x => x.SenderId == id).ToList();
            }
        }
    }
}
