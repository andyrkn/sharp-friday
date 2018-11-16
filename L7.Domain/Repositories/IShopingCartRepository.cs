namespace L7.Domain
{
    public interface IShopingCartRepository : IReadRepository<ShoppingCart>, IWriteRepository<ShoppingCart>
    {
    }
}