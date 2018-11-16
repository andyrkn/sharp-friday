using CSharpFunctionalExtensions;
using EnsureThat;
using L7.Domain;
using MediatR;

namespace L7.Business
{
    public class EditShoppingCartCommandHandler : RequestHandler<EditShoppingCartCommand, Result>
    {
        private readonly IShopingCartRepository repository;

        public EditShoppingCartCommandHandler(IShopingCartRepository repository)
        {
            EnsureArg.IsNotNull(repository);
            this.repository = repository;
        }

        protected override Result Handle(EditShoppingCartCommand request)
        {
            EnsureArg.IsNotNull(request);

            var existingShoppingCartOrNothing = repository.GetById(request.Id);

            return existingShoppingCartOrNothing.ToResult(ErrorMessages.ShoppingCartNotFound)
                .OnSuccess(s => UpdateShoppingCart(s, request));
        }

        private void UpdateShoppingCart(Domain.ShoppingCart shoppingCart, EditShoppingCartCommand request)
        {
            shoppingCart.Update(request.Model.Description);
            repository.Update(shoppingCart);
            repository.Save();
        }
    }
}