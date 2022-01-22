using Data;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Services
{
    public class ShoppingCartService : IShoppingCartService
    {
        public string Id { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }

        private WorldtechDbContext _worldTechDbContext;
        public ShoppingCartService(WorldtechDbContext worldTechContext)
        {
            this._worldTechDbContext = worldTechContext;
        }


        public static ShoppingCartService GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var worldTechContext = services.GetService<WorldtechDbContext>();

            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", cartId);

            return new ShoppingCartService(worldTechContext) { Id = cartId };
        }

        public void AddToCart(Product product, int amount)
        {
            var shoppingCardItem = GetCartItemById(product.Id);

            if (shoppingCardItem == null)
            {
                shoppingCardItem = new ShoppingCartItem()
                {
                    ShoppingCartId = Id,
                    Product = product,
                    Amount = amount
                };

                _worldTechDbContext.ShoppingCartItems.Add(shoppingCardItem);
            }
            else
            {
                shoppingCardItem.Amount++;
            }

            _worldTechDbContext.SaveChanges();
        }

        public ShoppingCartItem GetCartItemById(int productId)
        {
            return _worldTechDbContext.ShoppingCartItems.SingleOrDefault(cartItem =>
                                         cartItem.Product.Id == productId &&
                                         cartItem.ShoppingCartId == this.Id);
        }

        public int RemoveFromCart(Product product)
        {
            var shoppingCardItem = GetCartItemById(product.Id);

            var localAmount = 0;
            if (shoppingCardItem != null)
            {
                if (shoppingCardItem.Amount > 1)
                {
                    shoppingCardItem.Amount--;
                    localAmount = shoppingCardItem.Amount;
                }
                else _worldTechDbContext.ShoppingCartItems.Remove(shoppingCardItem);
            }
            _worldTechDbContext.SaveChanges();

            return localAmount;
        }

        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            if (this.ShoppingCartItems == null) return _worldTechDbContext.ShoppingCartItems
                    .Where(cartItem => cartItem.ShoppingCartId == this.Id)
                    .Include(cartItem => cartItem.Product)
                    .ToList();
            else return this.ShoppingCartItems;
        }

        public void ClearCart()
        {
            var cartItems = _worldTechDbContext.ShoppingCartItems.Where(cartItem => cartItem.ShoppingCartId == this.Id);
            _worldTechDbContext.RemoveRange(cartItems);

            List<CurrentOrderDetail> currentOrders = _worldTechDbContext.CurrentOrderDetails.ToList();
            _worldTechDbContext.RemoveRange(currentOrders);

            _worldTechDbContext.SaveChanges();
        }

        public int GetNumberOfItems()
        {
            int numberOfItems = _worldTechDbContext.ShoppingCartItems
                .Where(carItem => carItem.ShoppingCartId == this.Id)
                .Select(cartItem => cartItem.Amount)
                .Sum();

            return numberOfItems;
        }

        public decimal GetTotalPrice()
        {
            decimal totalPrice = (decimal)_worldTechDbContext.ShoppingCartItems
                .Where(cartItem => cartItem.ShoppingCartId == this.Id)
                .Select(cartItem => cartItem.Product.Price * cartItem.Amount)
                .Sum();

            return totalPrice;
        }
    }
}