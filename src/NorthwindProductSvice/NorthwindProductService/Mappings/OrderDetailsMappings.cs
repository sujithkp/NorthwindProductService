
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NorthwindProductService.Entities;

namespace NorthwindProductService.Mappings
{
    public class OrderDetailsMappings : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.HasKey(x => new { x.OrderID, x.ProductID });
            builder.HasOne(x => x.Order);

            builder.Property(x => x.Quantity);
            builder.Property(x => x.UnitPrice);
            builder.Property(x => x.Discount);
        }
    }
}
