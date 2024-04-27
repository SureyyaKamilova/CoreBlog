using BusinessLayer.Interfaces;
using DataAccessLayer.EntityFrameworks;
using DataAccessLayer.Interfaces;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategory _category;
        public CategoryManager(ICategory category)
        {
            _category = category;
        }

        public Category GetById(int id)
        {
            return _category.GetById(id);
        }

        public List<Category> GetList()
        {
            return _category.GetAll();
        }

        public void TAdd(Category category)
        {
            _category.Insert(category);
        }

        public void TDelete(Category category)
        {
            _category.Delete(category);
        }

        public void TUpdate(Category category)
        {
            _category.Update(category);
        }
    }
}
