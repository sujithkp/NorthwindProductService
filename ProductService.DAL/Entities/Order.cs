using System;

namespace ProductService.DAL.Entities
{
    internal class Order
    {
        public int OrderId { get; set; }

        public int? RowVersion { get; set; }

        public DateTime? CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public string Description { get; set; }
    }
}
