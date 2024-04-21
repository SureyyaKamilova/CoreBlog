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
	public class WriterManager : IWriterService
	{
		private readonly IWriter _writer;
		public WriterManager(IWriter writer)
		{
			_writer = writer;
		}

		public void WriterAdd(Writer writer)
		{
			_writer.Insert(writer);
		}
	}
}
