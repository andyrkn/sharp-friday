namespace L7.Domain
{
    public interface IProductRepository : IReadRepository<Product>, IWriteRepository<Product>
    {
    }
}