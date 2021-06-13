using ProductService.DAL.EntityDto;
using ProductService.DAL.Entities;
using System.Collections.Generic;

namespace ProductService.DAL
{
    public interface IProductDomainController
    {
        ProductDto GetProduct(int id);

        IList<ProductDto> GetProducts();
    }
}
