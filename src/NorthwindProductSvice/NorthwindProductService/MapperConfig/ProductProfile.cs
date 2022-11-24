using AutoMapper;
using NorthwindProductService.Entities;
using NorthwindProductService.Model;

namespace NorthwindProductService.MapperConfig
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Products, ProductInfo>();

            CreateMap<Categories, CategoryInfo>();

        }
    }
}
