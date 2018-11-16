using System;
using L7.Common;

namespace L7.Business
{
    public class DeleteProductCommand : ICommand
    {
        public Guid Id { get; }

        public DeleteProductCommand(Guid id)
        {
            Id = id;
        }
    }
}