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

        public void CategoryAdd(Category category)
        {
            _category.Insert(category);
        }

        public void CategoryDelete(Category category)
        {
            _category.Delete(category);
        }

        public void CategoryUpdate(Category category)
        {
            _category.Update(category);
        }

        public List<Category> GetAll()
        {
            return _category.GetAll();
        }

        public Category GetById(int id)
        {
            return _category.GetById(id);
        }
    }
}
