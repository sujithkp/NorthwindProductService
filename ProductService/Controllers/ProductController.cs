using Microsoft.AspNetCore.Mvc;
using ProductService.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.Controllers
{
    public class ProductController : Controller
    {
        private IProductDomainController _productDomainController;

        public ProductController(IProductDomainController domainController)
        {
            _productDomainController = domainController;
        }

        public IActionResult Index(int id)
        {
            var products = _productDomainController.GetProduct(id);

            return Json(products);
        }
    }
}
