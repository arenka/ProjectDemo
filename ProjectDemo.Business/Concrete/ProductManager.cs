using ProjectDemo.Business.Abstract;
using ProjectDemo.DataAccess.Abstract;
using ProjectDemo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectDemo.Business.Concrete
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }
        
        public void Add(Product product)
        {
            _productDal.Add(product);
        }

        public void Delete(int productId)
        {
            _productDal.Delete(new Product { ProductId = productId });
        }

        public List<Product> GetAll()
        {
            return _productDal.GetList();
        }

        public List<Product> GetByCategoryName(int categoryId)
        {
            return _productDal.GetList(x => x.CategoryId == categoryId|| categoryId == 0);
        }

        public Product GetById(int productId)
        {
            return _productDal.Get(c => c.ProductId == productId);
        }

        public void Update(Product product)
        {
            _productDal.Update(product);
        }
    }
}
