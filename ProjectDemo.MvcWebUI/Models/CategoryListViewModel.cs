using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectDemo.Entities.Concrete;

namespace ProjectDemo.MvcWebUI.Models
{
    public class CategoryListViewModel
    {
        public List<Category> Categories { get; set; }
        public int CurrentCategory { get; internal set; }
    }
}
