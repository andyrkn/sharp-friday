using L7.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace L7.Persistance
{
    public class ShoppingCartConfiguration : IEntityTypeConfiguration<ShoppingCart>
    {
        public void Configure(EntityTypeBuilder<ShoppingCart> builder)
        {
            builder.Ignore(x => x.Total);
            builder.Property(x => x.Description).IsRequired();
            builder.Property(x => x.Date).IsRequired();
            builder.HasMany(x => x.ProductPrices).WithOne();
        }
    }
}