using Microsoft.Extensions.Configuration;
using ProductService.DAL.Entities;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using ProductService.DAL.Dto;
using Microsoft.EntityFrameworkCore;

namespace ProductService.DAL
{
    public class ProductDomainController : IProductDomainController
    {
        private DbContext.ProductDomainDbContext _dbContext;

        private IConfigurationRoot _configuration;

        public ProductDomainController(IProductDomainConfiguration configuration)
        {
            InitializeDbContext(configuration.ConnectionString);
        }

        public Product GetProduct(int productId)
        {
            return _dbContext.Products
                .Where(x => x.ProductId == productId).SingleOrDefault();
        }

        public IList<Product> GetProductsByCategory(int category)
        {
            var order = new Order()
            {
                Description = "Sample Order"
            };

            _dbContext.Orders.Add(order);
            var id = _dbContext.SaveChanges();

             order = _dbContext.Orders.Where(o => o.OrderId == 1).SingleOrDefault();
            order.Description = "Sample order2";

            var id2 = _dbContext.SaveChanges();

            return _dbContext.Products.Where(x => x.Category.CategoryId == category).ToList();
        }

        public IList<ProductSummary> GetProducts()
        {
            return _dbContext.Products.Select(x => new ProductSummary()
            {
                Id = x.ProductId,
                Name = x.ProductName
            }).ToList();
        }

        private void InitializeDbContext(string connStr)
        {
            _dbContext = new DbContext.ProductDomainDbContext(connStr);

        }
    }
}
