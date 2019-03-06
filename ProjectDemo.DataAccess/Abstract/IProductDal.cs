using ProjectDemo.Core.DataAccess;
using ProjectDemo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectDemo.DataAccess.Abstract
{
    public interface IProductDal : IEntityRepository<Product>
    {
       
    }

}
