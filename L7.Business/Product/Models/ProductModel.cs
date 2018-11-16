using System;

namespace L7.Business
{
    public class ProductModel : UpsertProductModel
    {
        public decimal Total { get; set; }

        public Guid Id { get; set; }
    }
}