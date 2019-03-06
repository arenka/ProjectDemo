using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using ProjectDemo.Entities.Concrete;
using ProjectDemo.MvcWebUI.ExtensionMethods;

namespace ProjectDemo.MvcWebUI.Services
{
    public class CartSessionService : ICartSessionService
    {
        private IHttpContextAccessor _httpContextAccessor;

        public CartSessionService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }


        public Cart GetCart()
        {
            Cart checkToCart = _httpContextAccessor.HttpContext.Session.GetObject<Cart>("cart");

            if (checkToCart==null)
            {
                _httpContextAccessor.HttpContext.Session.SetObject("cart",new Cart());
                checkToCart = _httpContextAccessor.HttpContext.Session.GetObject<Cart>("cart");

            }
            return checkToCart;

        }   

        public void SetCart(Cart cart)
        {
            _httpContextAccessor.HttpContext.Session.SetObject("cart", cart);
        }
    }
}
