using System;
using System.IO;
using System.Linq;

namespace ProductService.DAL
{
    class Program
    {
        static void Main(string[] args)
        {
            var pdc = new ProductDomainController(new ProductDomainConfiguration()
            {
                ConnectionString = Environment.CurrentDirectory
                    + Path.DirectorySeparatorChar + "Data"
                    + Path.DirectorySeparatorChar + "Products.db"
            });

            var product = pdc.GetProductsByCategory(1);
        }
    }
}
