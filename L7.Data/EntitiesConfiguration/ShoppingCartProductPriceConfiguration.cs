using L7.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace L7.Persistance
{
    public class ShoppingCartProductPriceConfiguration : IEntityTypeConfiguration<ShoppingCartProductPrice>
    {
        public void Configure(EntityTypeBuilder<ShoppingCartProductPrice> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne<ShoppingCart>().WithMany(x => x.ProductPrices).HasForeignKey(x => x.ShoppingCartId);
        }
    }
}