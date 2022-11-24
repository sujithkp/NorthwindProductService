﻿using System.ComponentModel.DataAnnotations.Schema;

namespace NorthwindProductService.Entities
{
    [Table("Order Details")]
    public class OrderDetail
    {
        public int OrderID { get; set; }

        public int ProductID { get; set; }

        public decimal UnitPrice { get; set; }

        public short Quantity { get; set; }

        public float Discount { get; set; }

        public Order Order { get; set; }
    }
}
