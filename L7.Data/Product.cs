using System;

namespace L7.Data
{
    public class Product
    {
        private Product()
        {

        }

        public Product(string name, int price, int pieces)
        {
            Id = new Guid();
            Name = name;
            Price = price;
            Pieces = pieces;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public int Price { get; private set; }
        public int Pieces { get; private set; }
    }
}
