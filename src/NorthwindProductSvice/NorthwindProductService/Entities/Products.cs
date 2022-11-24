using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NorthwindProductService.Entities
{
    public class Products
    {
        [Key]
        public int ProductID { get; set; }

        public string? ProductName { get; set; }

        public int? CategoryID { get; set; }

        [ForeignKey(nameof(CategoryID))]
        public Categories? Category { get; set; }
    }
}
