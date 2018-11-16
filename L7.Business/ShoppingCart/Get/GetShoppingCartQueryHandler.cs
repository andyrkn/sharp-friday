using AutoMapper;
using CSharpFunctionalExtensions;
using EnsureThat;
using L7.Domain;
using MediatR;

namespace L7.Business
{
    public class GetShoppingCartQueryHandler : RequestHandler<GetShoppingCartQuery, Result<ShoppingCartModel>>
    {
        private readonly IShopingCartRepository repository;
        private readonly IMapper mapper;

        public GetShoppingCartQueryHandler(IShopingCartRepository repository, IMapper mapper)
        {
            EnsureArg.IsNotNull(repository);
            this.repository = repository;
            this.mapper = mapper;
        }

        protected override Result<ShoppingCartModel> Handle(GetShoppingCartQuery request)
        {
            EnsureArg.IsNotNull(request);

            var shoppingCartOrNothing = repository.GetById(request.Id);

            return shoppingCartOrNothing.ToResult(ErrorMessages.ShoppingCartNotFound)
                .Map(s => mapper.Map<ShoppingCartModel>(s));
        }
    }
}