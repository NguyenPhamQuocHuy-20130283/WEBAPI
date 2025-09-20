
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using API.Models;

namespace API.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {

            builder.ToTable("Product");
            // Định nghĩa khóa chính
            builder.HasKey(p => p.Id);
            // Cấu hình các cột
            builder.Property(p => p.Title)
                   .IsRequired()
                   .HasMaxLength(100); // Giới hạn độ dài chuỗi Title

            builder.Property(p => p.Name)
                   .IsRequired()
                   .HasMaxLength(200); // Giới hạn độ dài chuỗi Name

            builder.Property(p => p.Description)
                   .HasMaxLength(500); // Giới hạn độ dài chuỗi Description

            builder.Property(p => p.Url)
                   .HasMaxLength(200); // Giới hạn độ dài chuỗi Url

            builder.Property(p => p.Gender)
                   .HasMaxLength(10); // Giới hạn độ dài chuỗi Gender

            builder.Property(p => p.Price)
                   .IsRequired()
                   .HasColumnType("decimal(18,2)"); // Kiểu dữ liệu Price (decimal với độ chính xác 18,2)

            builder.Property(p => p.ProductImageUrl)
                   .HasMaxLength(500); // Giới hạn độ dài chuỗi ProductImageUrl

            // Các cấu hình bổ sung nếu cần


        }
    }
}
