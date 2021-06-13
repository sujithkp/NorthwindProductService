namespace ProductService.DAL.EntityDto
{
    public class ProductDto
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public CategoryDto Category { get; set; }

        public string QuantityPerUnit { get; set; }

        public decimal UnitPrice { get; set; }

        public int UnitsInStock { get; set; }

        public int UnitsOnOrder { get; set; }

        public int ReorderLevel { get; set; }

        public string Discontinued { get; set; }
    }
}
