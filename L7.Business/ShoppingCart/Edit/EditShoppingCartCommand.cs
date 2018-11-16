using System;
using L7.Common;

namespace L7.Business
{
    public class EditShoppingCartCommand : ICommand
    {
        public Guid Id { get; }
        public UpsertShoppingCartModel Model { get; }

        public EditShoppingCartCommand(Guid id, UpsertShoppingCartModel model)
        {
            Id = id;
            Model = model;
        }
    }
}