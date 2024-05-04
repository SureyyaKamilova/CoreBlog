using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface IMessageService:IGenericService<Message>
    {
        List<Message> GetInboxListByWriter(string writer);
    }
}
