using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NorthwindProductService.Entities;

namespace NorthwindProductService.Mappings
{
    public class OrderMappings : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(o => o.OrderID);

            builder.Property(o => o.ShipCity);

            builder.Property(o => o.ShipPostalCode);

            builder.Property(o => o.ShipCountry);

            builder.HasMany(o => o.Details);

            builder.Property(o => o.ShipingName).HasColumnName("ShipName");

            builder.Property(o => o.ShipingName).HasColumnName("ShipName");

            builder.Property(o => o.ShippingAddress).HasColumnName("ShipAddress");
        }
    }
}
