using L7.Common;

namespace L7.Business
{
    public class AddShoppingCartCommand : ICommand<ShoppingCartModel>
    {
        public UpsertShoppingCartModel Model { get; }

        public AddShoppingCartCommand(UpsertShoppingCartModel model)
        {
            Model = model;
        }
    }
}