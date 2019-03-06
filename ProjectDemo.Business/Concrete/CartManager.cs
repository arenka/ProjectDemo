using ProjectDemo.Business.Abstract;
using ProjectDemo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectDemo.Business.Concrete
{
    public class CartManager : ICartService
    {
        public void AddToCart(Cart cart, Product product)
        {
            CartLine cartLine = cart.CartLines.FirstOrDefault(x => x.Product.ProductId == product.ProductId);
            if (cartLine!=null)
            {
                cartLine.Quantity++;
                return; 
            }
            cart.CartLines.Add(new CartLine { Product = product, Quantity = 1 });
        }

        public List<CartLine> List(Cart cart)
        {
            return cart.CartLines;
        }

        public void RemoveFromCart(Cart cart, int productId)
        {
            var product = cart.CartLines.FirstOrDefault(x => x.Product.ProductId == productId);
            if (product.Quantity==1)
            {
                cart.CartLines.Remove(product);
            }
            else
            {
                product.Quantity--;
            }
            
        }
    }
}
