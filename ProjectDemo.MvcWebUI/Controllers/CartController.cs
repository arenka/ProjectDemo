using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectDemo.Business.Abstract;
using ProjectDemo.Entities.Concrete;
using ProjectDemo.MvcWebUI.Models;
using ProjectDemo.MvcWebUI.Services;

namespace ProjectDemo.MvcWebUI.Controllers
{
    public class CartController : Controller
    {
        private ICartSessionService _cartSessionService;
        private ICartService _cartService;
        private IProductService _productService;
        public CartController(ICartSessionService cartSessionService,
                              ICartService cartService,
                              IProductService productService)
        {
            _cartSessionService = cartSessionService;
            _cartService = cartService;
            _productService = productService;
        }

        public IActionResult AddToCart(int productId)
        {
            var productToBeAdded = _productService.GetById(productId);
            var cart = _cartSessionService.GetCart();

            _cartService.AddToCart(cart, productToBeAdded);
            _cartSessionService.SetCart(cart);

            TempData.Add("message", string.Format("Your Product, {0}, was successfully added to cart...", productToBeAdded.ProductName));

            return RedirectToAction("Index", "Product");
        }

        public IActionResult List()
        {
            var cart = _cartSessionService.GetCart();
            CartSummaryViewModel cartSummaryViewModel = new CartSummaryViewModel
            {
                Cart = cart
            };
            return View(cartSummaryViewModel);
        }

        public IActionResult Remove(int productId)
        {
            var cart = _cartSessionService.GetCart();
            _cartService.RemoveFromCart(cart, productId);
            _cartSessionService.SetCart(cart);
            TempData.Add("message", string.Format("Your Product, was successfully deleted to cart..."));
            return RedirectToAction("List");

        }

        public IActionResult Complete()
        {
            var shippingDetailsNewModel = new ShippingDetailsNewModel
            {
                ShippingDetails = new ShippingDetails() 
            };
            return View(shippingDetailsNewModel);
        }

        [HttpPost]
        public IActionResult Complete(ShippingDetails shippingDetails)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            TempData.Add("message", String.Format("Thank You, {0} ,", shippingDetails.FirstName));

            return View();
        }
    }
}