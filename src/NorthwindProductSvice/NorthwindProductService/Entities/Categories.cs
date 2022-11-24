using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NorthwindProductService.Entities
{
    public class Categories
    {
        [Key]
        public int CategoryID { get; set; }

        public string CategoryName { get; set; }

        public string Description { get; set; }

        [InverseProperty("Category")]
        public List<Products> Products { get; set; }
    }
}
