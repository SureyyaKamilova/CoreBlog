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

        public Writer GetById(int id)
        {
            return _writer.GetById(id);
        }

        public List<Writer> GetList()
        {
            return _writer.GetAll();
        }

        public List<Writer> GetWriterById(int id)
        {
            return _writer.GetList(x => x.WriterId == id);
        }

        public void TAdd(Writer writer)
        {
            _writer.Insert(writer);
        }

        public void TDelete(Writer writer)
        {
            _writer.Delete(writer);
        }

        public void TUpdate(Writer writer)
        {
            _writer.Update(writer);
        }

	}
}
