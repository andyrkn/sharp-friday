using System;
using CSharpFunctionalExtensions;
using L7.Common;

namespace L7.Business
{
    public class GetShoppingCartQuery : IQuery<Result<ShoppingCartModel>>
    {
        public Guid Id { get; }

        public GetShoppingCartQuery(Guid id)
        {
            Id = id;
        }
    }
}