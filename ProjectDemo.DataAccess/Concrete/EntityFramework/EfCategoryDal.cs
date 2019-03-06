using ProjectDemo.Core.DataAccess.EntityFramework;
using ProjectDemo.DataAccess.Abstract;
using ProjectDemo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectDemo.DataAccess.Concrete.EntityFramework
{
    public class EfCategoryDal : EfEntityRepositoryBase<Category, ProjectDemoContext>, ICategoryDal
    {
       
    }
}
