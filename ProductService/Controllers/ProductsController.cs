using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductService.DAL;

namespace ProductService.Controllers
{
    [Route("[Controller]")]
    [ApiController]
    public class ProductsController : Controller
    {
        private IProductDomainController _productDomainController;

        public ProductsController(IProductDomainController domainController)
        {
            _productDomainController = domainController;
        }

        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            return Json(_productDomainController.GetProducts());
        }
    }
}
