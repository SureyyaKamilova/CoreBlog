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
	public class NewsLetterManager : INewsLetterService
	{
		INewsLetter _newsLetter;
		public NewsLetterManager(INewsLetter newsLetter)
		{
			_newsLetter = newsLetter;
		}

		public void AddNewsLetter(NewsLetter newsLetter)
		{
			_newsLetter.Insert(newsLetter);
		}
	}
}
