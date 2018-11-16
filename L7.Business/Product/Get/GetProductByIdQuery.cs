using System;
using CSharpFunctionalExtensions;
using L7.Common;

namespace L7.Business
{
    public class GetProductByIdQuery : IQuery<Result<ProductModel>>
    {
        public Guid Id { get; }

        public GetProductByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}