using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IMessage2:IGeneric<Message2>
    {
        List<Message2> GetListWithMessageByWriter(int id);
    }
}
