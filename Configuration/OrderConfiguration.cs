using API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Configuration
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Order");

            // Định nghĩa khóa chính
            builder.HasKey(o => o.OrderID);

            // Các thuộc tính của Order
            builder.Property(o => o.OrderID).IsRequired();
            builder.Property(o => o.OrderCode).HasMaxLength(100);
            builder.Property(o => o.CustomerID).IsRequired();
            builder.Property(o => o.TotalAmount).HasColumnType("decimal(18,2)").IsRequired();
            builder.Property(o => o.OrderDate).IsRequired().HasDefaultValueSql("CURRENT_TIMESTAMP");
            builder.Property(o => o.Status).HasMaxLength(50).IsRequired();
            builder.Property(o => o.DeliveryMethod).HasMaxLength(50);
            builder.Property(o => o.PaymentMethod).HasMaxLength(50);
            builder.Property(o => o.Address).HasMaxLength(200).IsRequired();

            // Liên kết với OrderItems
            builder.HasMany(o => o.OrderItems)
                   .WithOne(oi => oi.Order)
                   .HasForeignKey(oi => oi.Id);
        }
    }
}