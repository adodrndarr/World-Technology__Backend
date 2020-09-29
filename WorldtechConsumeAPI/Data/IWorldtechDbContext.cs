using Domain;
using Microsoft.EntityFrameworkCore;


namespace Data
{
    public interface IWorldtechDbContext
    {
        DbSet<Product> Products { get; set; }
        DbSet<Product> Computers { get; set; }
        DbSet<Product> Gadgets { get; set; }
        DbSet<Product> Laptops { get; set; }

        DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }

        DbSet<Order> Orders { get; set; }
        DbSet<OrderDetail> OrderDetails { get; set; }
        DbSet<CurrentOrderDetail> CurrentOrderDetails { get; set; }
    }
}