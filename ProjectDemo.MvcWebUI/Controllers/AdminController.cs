using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectDemo.Business.Abstract;
using ProjectDemo.Entities.Concrete;
using ProjectDemo.MvcWebUI.Models;

namespace ProjectDemo.MvcWebUI.Controllers
{
    [Authorize(Roles ="Admin")]
    public class AdminController : Controller
    {
        IProductService _productService;
        ICategoryService _categoryService;
        public AdminController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }
        public IActionResult Index()
        {
            var productListViewModel = new ProductListViewModel
            {
                Products = _productService.GetAll()
            };
            return View(productListViewModel);
        }

        public IActionResult Add()
        {
            var model = new ProductAddViewModel
            {
                Product = new Product(),
                Categories = _categoryService.GetAll()
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Add(Product product)
        {
            if (ModelState.IsValid)
            {
                _productService.Add(product);
                TempData.Add("message", "Product was successfully added");
                return RedirectToAction("Index");
            }
            return RedirectToAction("Add");
        }

        public IActionResult Update(int productid)
        {
            var model = new ProductUpdateViewModel
            {
                Product = _productService.GetById(productid),
                Categories = _categoryService.GetAll()
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Update(Product product)
        {
            if (ModelState.IsValid)
            {
                _productService.Update(product);
                TempData.Add("message", "Product was successfully updated");
                return RedirectToAction("Index");
            }
            return RedirectToAction("Update");
        }

        public IActionResult Delete(int productid)
        {
            _productService.Delete(productid);
            TempData.Add("message", "Product was successfully deleted");
            return RedirectToAction("Index");
        }


    }
}
