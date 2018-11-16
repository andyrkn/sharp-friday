using CSharpFunctionalExtensions;
using EnsureThat;
using L7.Domain;
using MediatR;

namespace L7.Business
{
    public class DeleteShoppingCartCommandHandler : RequestHandler<DeleteShoppingCartCommand, Result>
    {
        private readonly IShopingCartRepository repository;

        public DeleteShoppingCartCommandHandler(IShopingCartRepository repository)
        {
            EnsureArg.IsNotNull(repository);
            this.repository = repository;
        }

        protected override Result Handle(DeleteShoppingCartCommand request)
        {
            EnsureArg.IsNotNull(request);

            var shoppingCartOrNothing = repository.GetById(request.Id);

            return shoppingCartOrNothing.ToResult(ErrorMessages.ShoppingCartNotFound)
                .OnSuccess(s => repository.Delete(s))
                .OnSuccess(_ => repository.Save());
        }
    }
}