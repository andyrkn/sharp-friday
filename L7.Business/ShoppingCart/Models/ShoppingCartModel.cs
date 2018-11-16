using System;

namespace L7.Business
{
    public class ShoppingCartModel : BaseModel
    {
        public string Description { get; set; }

        public DateTime Date { get; set; }

        public decimal Total { get; set; }
    }
}