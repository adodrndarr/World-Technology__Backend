using Domain;
using System.Collections.Generic;


namespace Services
{
    public interface IShoppingCartService
    {
        string Id { get; set; }
        List<ShoppingCartItem> ShoppingCartItems { get; set; }

        void AddToCart(Product product, int amount);
        void ClearCart();
        ShoppingCartItem GetCartItemById(int id);
        List<ShoppingCartItem> GetShoppingCartItems();

        int GetNumberOfItems();
        decimal GetTotalPrice();
        int RemoveFromCart(Product product);
    }
}
