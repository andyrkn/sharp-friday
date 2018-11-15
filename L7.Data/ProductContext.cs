using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace L7.Data
{
    class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options ): base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Product> Products { get; set; }
    }
}
