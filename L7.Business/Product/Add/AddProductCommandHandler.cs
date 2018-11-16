using AutoMapper;
using EnsureThat;
using L7.Domain;
using MediatR;

namespace L7.Business
{
    public class AddProductCommandHandler : RequestHandler<AddProductCommand, ProductModel>
    {
        private readonly IProductRepository repository;
        private readonly IMapper mapper;
    
        public AddProductCommandHandler(IProductRepository repository, IMapper mapper)
        {
            EnsureArg.IsNotNull(mapper);
            EnsureArg.IsNotNull(repository);
            this.repository = repository;
            this.mapper = mapper;
        }
        protected override ProductModel Handle(AddProductCommand request)
        {
            EnsureArg.IsNotNull(request);

            var product = Domain.Product.Create(request.Model.Name, request.Model.Price, request.Model.Pieces);
            repository.Add(product);
            repository.Save();

            return mapper.Map<ProductModel>(product);
        }

    }
}