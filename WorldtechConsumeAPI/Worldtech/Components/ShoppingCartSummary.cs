using Microsoft.AspNetCore.Mvc;
using Services;
using Worldtech.Models;


namespace Worldtech.Components
{
    public class ShoppingCartSummary : ViewComponent
    {
        private readonly ShoppingCartService _shoppingCart;
        public ShoppingCartSummary(ShoppingCartService shoppingCart)
        {
            this._shoppingCart = shoppingCart;
        }


        public IViewComponentResult Invoke()
        {
            var cartItems = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = cartItems;

            var shoppingCartView = new ShoppingCartViewModel()
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetTotalPrice(),
                NumberOfItems = _shoppingCart.GetNumberOfItems()
            };

            return View(shoppingCartView);
        }
    }
}