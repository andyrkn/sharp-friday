using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace L7.Data
{
    class ShoppingCartContext:  DbContext
    {
        public ShoppingCartContext(DbContextOptions<ShoppingCartContext> options ): base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
    }
}
