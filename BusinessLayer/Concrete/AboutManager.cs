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
	public class AboutManager : IAboutService
	{
		private readonly IAbout _about;
		public AboutManager(IAbout about)
		{
			_about = about;
		}

        public About GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<About> GetList()
		{
			return _about.GetAll();
		}

        public void TAdd(About t)
        {
            throw new NotImplementedException();
        }

        public void TDelete(About t)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(About t)
        {
            throw new NotImplementedException();
        }
    }
}
