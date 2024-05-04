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
    public class MessageManager : IMessageService
    {
        private readonly IMessage _message;
        public MessageManager(IMessage message)
        {
            _message = message;
        }

        public Message GetById(int id)
        {
            return _message.GetById(id);
        }

        public List<Message> GetList()
        {
            return _message.GetAll();
        }

        public List<Message> GetInboxListByWriter(string writer)
        {
            return _message.GetList(x => x.Reciever==writer);
        }

        public void TAdd(Message message)
        {
            _message.Insert(message);
        }

        public void TDelete(Message message)
        {
            _message.Delete(message);
        }

        public void TUpdate(Message message)
        {
            _message.Update(message);
        }
    }
}
