using System;
using System.Collections.Generic;
using System.Text;

namespace L7.Data
{
    class ShoppingCart
    {
        private ShoppingCart()
        {

        }

        public ShoppingCart(DateTime date, string description)
        {
            Id = new Guid();
            Date = date;
            Description = description;
        }

        public Guid Id { get; private set; }
        public DateTime Date { get; private set; }
        public string Description { get; private set; }
    }
}
