using ProjectDemo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectDemo.Business.Abstract
{
    public interface ICategoryService
    {
        List<Category> GetAll();
    }
}
