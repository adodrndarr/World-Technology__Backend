using Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace Data
{
    public class WorldtechDbContext : IdentityDbContext<IdentityUser>, IWorldtechDbContext
    {
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Product> Computers { get; set; }
        public virtual DbSet<Product> Gadgets { get; set; }
        public virtual DbSet<Product> Laptops { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }


        public virtual DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }

        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<CurrentOrderDetail> CurrentOrderDetails { get; set; }


        public WorldtechDbContext(DbContextOptions<WorldtechDbContext> options) : base(options) { }
    }
}
