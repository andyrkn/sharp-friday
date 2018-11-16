using L7.Domain;
using Microsoft.EntityFrameworkCore;

namespace L7.Persistance.Repositories
{
    public class ShoppingCartRepository : Repository<ShoppingCart>, IShopingCartRepository
    {
        public ShoppingCartRepository(ShopContext context) 
            : base(context)
        {
            enititesSet.Include(x => x.ProductPrices);
        }
    }
}