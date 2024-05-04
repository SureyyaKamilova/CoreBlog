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
    public class Message2Manager : IMessage2Service
    {
        private readonly IMessage2 _message2;
        public Message2Manager(IMessage2 message2)
        {
            _message2 = message2;
        }

        public Message2 GetById(int id)
        {
            return _message2.GetById(id);
        }

        public List<Message2> GetInboxListByWriter(int id)
        {
            return _message2.GetListWithMessageByWriter(id);
        }

        public List<Message2> GetList()
        {
            return _message2.GetAll();
        }

        public void TAdd(Message2 message2)
        {
            _message2.Insert(message2);
        }

        public void TDelete(Message2 message2)
        { 
            _message2.Delete(message2);
        }

        public void TUpdate(Message2 message2)
        {
            _message2.Update(message2);
        }
    }
}
