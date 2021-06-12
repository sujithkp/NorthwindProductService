using System;
using System.Collections.Generic;
using System.Text;

namespace ProductService.DAL
{
    public interface IProductDomainConfiguration
    {
        public string ConnectionString { get; }
    }
}
