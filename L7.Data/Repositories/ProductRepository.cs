using L7.Domain;

namespace L7.Persistance.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(ShopContext context) 
            : base(context)
        {
        }
    }
}