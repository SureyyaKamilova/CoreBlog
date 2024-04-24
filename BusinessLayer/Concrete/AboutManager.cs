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

		public List<About> GetList()
		{
			return _about.GetAll();
		}
	}
}
