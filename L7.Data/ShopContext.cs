using L7.Domain;
using Microsoft.EntityFrameworkCore;

namespace L7.Persistance
{
    public class ShopContext : DbContext
    {
        public ShopContext(DbContextOptions<ShopContext> options)
            : base(options)
        {
            Database.Migrate();
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<ShoppingCart> ShoppingCarts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new ProductConfiguration().Configure(modelBuilder.Entity<Product>());
            new ShoppingCartConfiguration().Configure(modelBuilder.Entity<ShoppingCart>());
            new ShoppingCartProductPriceConfiguration().Configure(modelBuilder.Entity<ShoppingCartProductPrice>());
        }
    }
}
