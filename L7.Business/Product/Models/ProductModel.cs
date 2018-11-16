using System;

namespace L7.Business {
    public class ProductModel : BaseModel {
     
        public decimal Value { get; set; }
        public int Pieces { get; set; }
        public decimal Total { get; set; }
    }
}