namespace NorthwindProductService.Model
{
    public class ProductInfo
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public CategoryInfo Category { get; set; }
    }

    public class CategoryInfo
    {
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }
    }
}
