using System;
using CSharpFunctionalExtensions;
using EnsureThat;
using L7.Domain;
using MediatR;

namespace L7.Business
{
    public class AddProductToShoppingCartCommandHandler : RequestHandler<AddProductToShoppingCartCommand, Result>
    {
        private readonly IShopingCartRepository shoppingCartRepository;
        private readonly IProductRepository productRepository;

        public AddProductToShoppingCartCommandHandler(IShopingCartRepository shoppingCartRepository, IProductRepository productRepository)
        {
            EnsureArg.IsNotNull(shoppingCartRepository);
            this.shoppingCartRepository = shoppingCartRepository;
            this.productRepository = productRepository;
        }

        protected override Result Handle(AddProductToShoppingCartCommand request)
        {
            EnsureArg.IsNotNull(request);

            var shoppingCartOrNothing = shoppingCartRepository.GetById(request.Id);

            return shoppingCartOrNothing.ToResult(ErrorMessages.ShoppingCartNotFound)
                .OnSuccess(s => AddProductToShoppingCart(s, request.Model.Id));
        }

        private Result AddProductToShoppingCart(ShoppingCart shoppingCart, Guid productId)
        {
            var productOrNothing = productRepository.GetById(productId);

            return productOrNothing.ToResult(ErrorMessages.ProdcutNotFound)
                .OnSuccess(p =>
                {
                    shoppingCart.AddProductPrice(p);
                    shoppingCartRepository.Update(shoppingCart);
                    shoppingCartRepository.Save();
                });
        }
    }
}