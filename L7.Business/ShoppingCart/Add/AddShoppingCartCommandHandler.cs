using AutoMapper;
using CSharpFunctionalExtensions;
using EnsureThat;
using L7.Domain;
using MediatR;

namespace L7.Business
{
    public class AddShoppingCartCommandHandler : RequestHandler<AddShoppingCartCommand, ShoppingCartModel>
    {
        private readonly IShopingCartRepository repository;
        private readonly IMapper mapper;

        public AddShoppingCartCommandHandler(IShopingCartRepository repository, IMapper mapper)
        {
            EnsureArg.IsNotNull(mapper);
            EnsureArg.IsNotNull(repository);
            this.repository = repository;
            this.mapper = mapper;
        }

        protected override ShoppingCartModel Handle(AddShoppingCartCommand request)
        {
            EnsureArg.IsNotNull(request);

            var shoppingCart = ShoppingCart.Create(request.Model.Description);
            repository.Add(shoppingCart);
            repository.Save();

            return mapper.Map<ShoppingCartModel>(shoppingCart);
        }
    }
}