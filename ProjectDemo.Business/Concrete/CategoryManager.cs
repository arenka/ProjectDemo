using ProjectDemo.Business.Abstract;
using ProjectDemo.DataAccess.Abstract;
using ProjectDemo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectDemo.Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public List<Category> GetAll()
        {
            return _categoryDal.GetList();
        }
    }
}
