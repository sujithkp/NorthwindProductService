using AutoMapper;
using ProductService.DAL.Entities;
using ProductService.DAL.EntityDto;

namespace ProductService.DAL.Mappers
{
    public static class ProductMapper
    {
        public static IMapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Category, CategoryDto>();
                cfg.CreateMap<CategoryDto, Category>();

                cfg.CreateMap<Product, ProductDto>();
                cfg.CreateMap<ProductDto, Product>();
            });

            return config.CreateMapper();
        }
    }
}
