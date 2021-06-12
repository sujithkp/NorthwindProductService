using System;
using System.Linq;

namespace ProductService.DAL
{
    class Program
    {
        static void Main(string[] args)
        {
            var pdc = new ProductDomainController(new ProductDomainConfiguration()
            { ConnectionString = "Data Source=C:\\Sqlite\\Products.db;" });

            var product = pdc.GetProductsByCategory(1);
        }
    }
}
