using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductService.DAL.Entities
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public virtual Category Category { get; set; }

        public string QuantityPerUnit { get; set; }

        public SupplierRef Supplier { get; set; }

        public decimal UnitPrice { get; set; }

        public int UnitsInStock { get; set; }

        public int UnitsOnOrder { get; set; }

        public int ReorderLevel { get; set; }

        public string Discontinued { get; set; }
    }

    public class SupplierRef
    {
        public int Id { get; set; }
    }
}
