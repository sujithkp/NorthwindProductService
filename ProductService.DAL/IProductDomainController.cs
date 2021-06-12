using ProductService.DAL.Dto;
using ProductService.DAL.Entities;
using System.Collections.Generic;

namespace ProductService.DAL
{
    public interface IProductDomainController
    {
        Product GetProduct(int id);

        IList<ProductSummary> GetProducts();
    }
}
