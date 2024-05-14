using BusinessLayer.Abstract;
using DataAccesLayer.Abstract;
using DataAccesLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager:ICategoryService
    {
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public List<Category> GettAll()
        {
            return _categoryDal.List();
        }
        public void CategoryStatusFalseBl(int id)
        {
            Category category = _categoryDal.Find(x => x.CategoryID == id);
            category.CategoryStatus = false;
            _categoryDal.Update(category);
        }
        public void CategoryStatusTrueBl(int id)
        {
            Category category = _categoryDal.Find(x => x.CategoryID == id);
            category.CategoryStatus = true;
             _categoryDal.Update(category);
        }

        public List<Category> GetList()
        {
            return _categoryDal.List();

        }

        public void CategoryAdd(Category category)
        {
            _categoryDal.Insert(category);
        }

        public Category GetByID(int id)
        {
           return _categoryDal.GetById(id);
        }

        public void CategoryDelete(Category category)
        {
            _categoryDal.Delete(category);
        }

        public void CategoryUpdate(Category category)
        {
            _categoryDal.Update(category);
        }
    }
}
