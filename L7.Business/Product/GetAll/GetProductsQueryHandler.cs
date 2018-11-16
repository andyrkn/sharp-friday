using System.Collections.Generic;
using AutoMapper;
using EnsureThat;
using L7.Domain;
using MediatR;

namespace L7.Business
{
    public class GetProductsQueryHandler : RequestHandler<GetProductsQuery, IEnumerable<ProductModel>>
    {
        private readonly IProductRepository productRepository;
        private readonly IMapper mapper;

        public GetProductsQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            EnsureArg.IsNotNull(productRepository);
            EnsureArg.IsNotNull(mapper);
            this.productRepository = productRepository;
            this.mapper = mapper;
        }

        protected override IEnumerable<ProductModel> Handle(GetProductsQuery request)
        {
            EnsureArg.IsNotNull(request);

            var products = productRepository.GetAll();

            return mapper.Map<IEnumerable<ProductModel>>(products);
        }
    }
}