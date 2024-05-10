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
    public class AdminManager : IAdminService
    {
        private readonly IAdmin _admin;
        public AdminManager(IAdmin admin)
        {
            _admin = admin;
        }

        public Admin GetById(int id)
        {
            return _admin.GetById(id);
        }

        public List<Admin> GetList()
        {
            return _admin.GetAll();
        }

        public void TAdd(Admin admin)
        {
            _admin.Insert(admin);
        }

        public void TDelete(Admin admin)
        {
            _admin.Delete(admin);
        }

        public void TUpdate(Admin admin)
        {
            _admin.Update(admin);
        }
    }
}
