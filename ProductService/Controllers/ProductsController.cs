using Microsoft.AspNetCore.Mvc;
using ProductService.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public IActionResult Index()
        {
            var products = _productDomainController.GetProducts();

            return Json(products);
        }
    }
}
