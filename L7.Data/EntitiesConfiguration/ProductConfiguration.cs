using L7.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace L7.Persistance
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Ignore(x => x.Total);
            builder.Property(x => x.Pieces).IsRequired();
            builder.Property(x => x.Name).IsRequired();
            builder.OwnsOne(x => x.Price, fn => fn.Property(p => p.Value).HasColumnType("DECIMAL (18, 2)").IsRequired());
        }
    }
}