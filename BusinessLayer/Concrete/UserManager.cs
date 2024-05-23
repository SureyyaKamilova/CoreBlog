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
    public class UserManager : IUserService
    {
        IUser _user;
        public UserManager(IUser user)
        {
            _user = user;
        }

        public AppUser GetById(int id)
        {
            return _user.GetById(id);
        }

        public List<AppUser> GetList()
        {
            return _user.GetAll();
        }

        public void TAdd(AppUser user)
        {
            _user.Insert(user);
        }

        public void TDelete(AppUser user)
        {
            _user.Delete(user);
        }

        public void TUpdate(AppUser user)
        {
            _user.Update(user);
        }
    }
}
