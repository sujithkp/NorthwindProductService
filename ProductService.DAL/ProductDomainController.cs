using AutoMapper;
using Microsoft.Extensions.Configuration;
using ProductService.DAL.Entities;
using ProductService.DAL.EntityDto;
using ProductService.DAL.Mappers;
using System.Collections.Generic;
using System.Linq;

namespace ProductService.DAL
{
    public class ProductDomainController : IProductDomainController
    {
        #region Fields

        private DbContext.ProductDomainDbContext _dbContext;

        private IConfigurationRoot _configuration;

        #endregion

        #region Properties 

        public IMapper Mapper { get; private set; }

        #endregion

        #region Constructor

        public ProductDomainController(IProductDomainConfiguration configuration)
        {
            Initialize(configuration.ConnectionString);
        }

        #endregion

        #region Public 

        public ProductDto GetProduct(int productId)
        {
            var productEntity = _dbContext.Products.Where(x => x.ProductId == productId).SingleOrDefault();

            return Mapper.Map<Product, ProductDto>(productEntity);
        }

        public IList<ProductDto> GetProductsByCategory(int categoryId)
        {
            var products = _dbContext.Products.Where(x => x.Category.CategoryId == categoryId).ToList();

            return Mapper.Map<IList<Product>, IList<ProductDto>>(products);
        }

        public IList<ProductDto> GetProducts()
        {
            return Mapper.Map<IList<Product>, IList<ProductDto>>(_dbContext.Products.ToList());
        }
        #endregion

        #region Privates

        private void Initialize(string connStr)
        {
            InitializeDbContext(connStr);
            InitializeMapper();
        }

        private void InitializeDbContext(string connStr)
        {
            _dbContext = new DbContext.ProductDomainDbContext(connStr);
        }

        private void InitializeMapper()
        {
            this.Mapper = ProductMapper.GetMapper();
        }

        #endregion
    }
}
