using AutoMapper;
using CSharpFunctionalExtensions;
using EnsureThat;
using L7.Domain;
using MediatR;

namespace L7.Business
{
    public class GetProductByIdQueryHandler : RequestHandler<GetProductByIdQuery, Result<ProductModel>>
    {
        private readonly IProductRepository repository;
        private readonly IMapper mapper;

        public GetProductByIdQueryHandler(IProductRepository repository, IMapper mapper)
        {
            EnsureArg.IsNotNull(mapper);
            EnsureArg.IsNotNull(repository);
            this.repository = repository;
            this.mapper = mapper;
        }

        protected override Result<ProductModel> Handle(GetProductByIdQuery request)
        {
            EnsureArg.IsNotNull(repository);

            var productOrNothing = repository.GetById(request.Id);

            return productOrNothing.ToResult(ErrorMessages.ProductNotFound)
                .Map(p => mapper.Map<ProductModel>(p));
        }
    }
}