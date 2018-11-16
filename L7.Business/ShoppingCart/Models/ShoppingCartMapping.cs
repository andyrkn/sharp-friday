using AutoMapper;
using L7.Domain;

namespace L7.Business
{
    public class ShoppingCartMapping : Profile
    {
        public ShoppingCartMapping()
        {
            CreateMap<ShoppingCart, ShoppingCartModel>();
        }
    }
}