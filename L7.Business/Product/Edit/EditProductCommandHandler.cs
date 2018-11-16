using CSharpFunctionalExtensions;
using EnsureThat;
using L7.Business.Product.Edit;
using L7.Domain;
using MediatR;
namespace L7.Business
{
    public class EditProductCommandHandler : RequestHandler<EditProductCommand, Result>
    {
        private readonly IProductRepository repository;

        public EditProductCommandHandler(IProductRepository repository)
        {
            EnsureArg.IsNotNull(repository);
            this.repository = repository;
        }
        protected override Result Handle(EditProductCommand request)
        {
            EnsureArg.IsNotNull(request);
            var existingProduct = repository.GetById(request.Id);

            return existingProduct.ToResult(ErrorMessages.ProductNotFound)
                .OnSuccess(p => Update(p, request.Model));
        }

        private void Update(Domain.Product product, UpsertProductModel model)
        {
            product.Update(model.Name, model.Price, model.Pieces);
            repository.Update(product);
            repository.Save();
        }

    }

}