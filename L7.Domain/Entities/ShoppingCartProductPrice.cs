using System;

namespace L7.Domain
{
    public class ShoppingCartProductPrice
    {
        private ShoppingCartProductPrice()
        {
        }

        public decimal Price { get; private set; }

        public Guid ShoppingCartId { get; private set; }

        public static ShoppingCartProductPrice Create(Price price, Guid shoppingCartId)
        {
            return new ShoppingCartProductPrice
            {
                Price = price.Value,
                ShoppingCartId = shoppingCartId
            };
        }
    }
}