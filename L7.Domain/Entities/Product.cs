namespace L7.Domain
{
    public sealed class Product : Entity
    {
        private Product()
        {
        }

        public string Name { get; private set; }

        public Price Price { get; private set; }

        public int Pieces { get; private set; }

        public decimal Total => Price.Value * Pieces;

        public static Product Create(string name, decimal price, int pieces)
        {
            return new Product
            {
                Name = name,
                Price = Price.Create(price),
                Pieces = pieces
            };
        }

        public void Update(string name, decimal price, int pieces)
        {
            Name = name;
            Price = Price.Create(price);
            Pieces = pieces;
        }
    }
}
