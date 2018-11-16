using System;
using L7.Common;

namespace L7.Business.Product.Edit
{
    public class EditProductCommand : ICommand
    {
        public Guid Id { get; }
        public UpsertProductModel Model { get; }

        public EditProductCommand(Guid id, UpsertProductModel model)
        {
            Id = id;
            Model = model;
        }
    }
}