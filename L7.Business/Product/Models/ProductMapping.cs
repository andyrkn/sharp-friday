using AutoMapper;
using L7.Domain;

namespace L7.Business
{
    public class ProductMapping : Profile
    {
        public ProductMapping(){
            CreateMap<Domain.Product, ProductModel>();
        }
    } 
}