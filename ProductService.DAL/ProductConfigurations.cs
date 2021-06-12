using System;
using System.Collections.Generic;
using System.Text;

namespace ProductService.DAL
{
    public class ProductDomainConfiguration : IProductDomainConfiguration
    {
        public string ConnectionString { get; set; }
    }
}
