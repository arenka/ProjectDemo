using System.Collections.Generic;
using ProjectDemo.Entities.Concrete;

namespace ProjectDemo.MvcWebUI.Models
{
    public class ProductUpdateViewModel
    {
        public Product Product { get; set; }
        public List<Category> Categories { get; internal set; }
    }
}