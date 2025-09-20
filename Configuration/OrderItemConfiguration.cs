using API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Configuration
{
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.ToTable("OrderItems");

            // Định nghĩa khóa chính
            builder.HasKey(oi => oi.Id);

            // Các thuộc tính của OrderItem
            builder.Property(oi => oi.Id).IsRequired();
            builder.Property(oi => oi.OrderID).IsRequired();
            builder.Property(oi => oi.ProductID).IsRequired();
            builder.Property(oi => oi.Quantity).IsRequired();
            builder.Property(oi => oi.UnitPrice).HasColumnType("decimal(18,2)").IsRequired();

            // Liên kết với Order và Product
            builder.HasOne(oi => oi.Order)
                   .WithMany(o => o.OrderItems)
                   .HasForeignKey(oi => oi.OrderID);

            builder.HasOne(oi => oi.Product)
                   .WithMany()
                   .HasForeignKey(oi => oi.ProductID);
        }
    }
}