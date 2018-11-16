using System.Collections.Generic;
using AutoMapper;
using EnsureThat;
using L7.Domain;
using MediatR;

namespace L7.Business
{
    public class GetShoppingCartsQueryHandler : RequestHandler<GetShoppingCartsQuery, IEnumerable<ShoppingCartModel>>
    {
        private readonly IShopingCartRepository repository;
        private readonly IMapper mapper;

        public GetShoppingCartsQueryHandler(IShopingCartRepository repository, IMapper mapper)
        {
            EnsureArg.IsNotNull(mapper);
            EnsureArg.IsNotNull(repository);
            this.repository = repository;
            this.mapper = mapper;
        }

        protected override IEnumerable<ShoppingCartModel> Handle(GetShoppingCartsQuery request)
        {
            EnsureArg.IsNotNull(request);
            var shoppingCarts = repository.GetAll();
            
            return mapper.Map<IEnumerable<ShoppingCartModel>>(shoppingCarts);
        }
    }
}