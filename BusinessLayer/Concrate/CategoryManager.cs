using BusinessLayer.Interfaces;
using DataAccessLayer.EntityFrameworks;
using EntityLayer.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrate
{
    public class CategoryManager : ICategoryService
    {
        EFCategoryRepository efCategoryRepository;
        public CategoryManager()
        {
            efCategoryRepository = new EFCategoryRepository();
        }
        public void CategoryAdd(Category category)
        {
            efCategoryRepository.Insert(category);
        }

        public void CategoryDelete(Category category)
        {
            efCategoryRepository.Delete(category);
        }

        public void CategoryUpdate(Category category)
        {
            efCategoryRepository.Update(category);
        }

        public List<Category> GetAll()
        {
            return efCategoryRepository.GetAll();
        }

        public Category GetById(int id)
        {
            return efCategoryRepository.GetById(id);
        }
    }
}
