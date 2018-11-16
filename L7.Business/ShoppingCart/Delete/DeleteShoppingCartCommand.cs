using System;
using L7.Common;

namespace L7.Business
{
    public class DeleteShoppingCartCommand : ICommand
    {
        public Guid Id { get; }

        public DeleteShoppingCartCommand(Guid id)
        {
            Id = id;
        }
    }
}