using L7.Common;

namespace L7.Business
{
    public class AddProductCommand : ICommand<ProductModel>
    {
        public UpsertProductModel Model { get; }
       
        public AddProductCommand(UpsertProductModel model)
        {
            Model = model;
        }
    }
}