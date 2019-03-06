using System.Collections.Generic;
using ProjectDemo.Entities.Concrete;

namespace ProjectDemo.MvcWebUI.Models
{
    public class ProductListViewModel
    {
        public ProductListViewModel()
        {
        }

        public List<Product> Products { get; set; }
        public int PageCount { get; internal set; }
        public int PageSize { get; internal set; }
        public int CurrentCategory { get; internal set; }
        public int CurrentPage { get; internal set; }
    }
}