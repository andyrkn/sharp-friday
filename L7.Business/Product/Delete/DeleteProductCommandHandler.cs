using CSharpFunctionalExtensions;
using EnsureThat;
using L7.Domain;
using MediatR;

namespace L7.Business
{
    public class DeleteProductCommandHandler : RequestHandler<DeleteProductCommand, Result>
    {
        private readonly IProductRepository repository;

        public DeleteProductCommandHandler(IProductRepository repository)
        {
            EnsureArg.IsNotNull(repository);
            this.repository = repository;
        }

        protected override Result Handle(DeleteProductCommand request)
        {
            EnsureArg.IsNotNull(request);

            var product = repository.GetById(request.Id);

            return product.ToResult(ErrorMessages.ProductNotFound)
                .OnSuccess(p => repository.Delete(p))
                .OnSuccess(_ => repository.Save());
        }
    }
}