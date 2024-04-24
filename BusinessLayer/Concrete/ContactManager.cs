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
	public class ContactManager : IContactService
	{
		private readonly IContact _contact;
		public ContactManager(IContact contact)
		{
			_contact = contact;
		}

		public void ContactAdd(Contact contact)
		{
			_contact.Insert(contact);
		}
	}
}
