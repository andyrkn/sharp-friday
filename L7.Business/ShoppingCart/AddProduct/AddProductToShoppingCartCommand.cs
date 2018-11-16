using System;
using L7.Common;

namespace L7.Business
{
    public class AddProductToShoppingCartCommand : ICommand
    {
        public Guid Id { get; }
        public AddProductToShoppingCartModel Model { get; }

        public AddProductToShoppingCartCommand(Guid id, AddProductToShoppingCartModel model)
        {
            Id = id;
            Model = model;
        }
    }
}