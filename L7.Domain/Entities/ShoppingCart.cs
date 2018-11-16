using System;
using System.Collections.Generic;
using System.Linq;

namespace L7.Domain
{
    public sealed class ShoppingCart : Entity
    {
        public DateTime Date { get; private set; }

        public string Description { get; private set; }

        private ICollection<ShoppingCartProductPrice> productPrices = new List<ShoppingCartProductPrice>();
        
        public IEnumerable<ShoppingCartProductPrice> ProductPrices
        {
            get => productPrices;
            private set => productPrices = value.ToList();
        }

        public decimal Total => productPrices.Sum(x => x.Price);

        private ShoppingCart()
        {
        }

        public static ShoppingCart Create(string description)
        {
            return new ShoppingCart
            {
                Date = DateTime.Now,
                Description = description
            };
        }

        public void Update(string description)
        {
            Description = description;
        }

        public void AddProductPrice(Product product)
        {
            productPrices.Add(ShoppingCartProductPrice.Create(product.Price, Id));
        }
    }
}
