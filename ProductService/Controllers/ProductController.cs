using Microsoft.AspNetCore.Mvc;
using ProductService.DAL;
using ProductService.DAL.EntityDto;

namespace ProductService.Controllers
{
    [Route("[Controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductDomainController _productDomainController;

        public ProductController(IProductDomainController domainController)
        {
            _productDomainController = domainController;
        }

        [HttpGet("{id?}")]
        public ProductDto Get(int? id)
        {
            var products = _productDomainController.GetProduct(id.Value);

            return products;
        }

       
    }
}
