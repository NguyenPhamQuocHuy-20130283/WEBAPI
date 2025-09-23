using API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Configuration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            // Đặt tên bảng
            builder.ToTable("Category");

            // Định nghĩa khóa chính
            builder.HasKey(c => c.Id);

            // Định nghĩa các thuộc tính
            builder.Property(c => c.Name)
                   .IsRequired()
                   .HasMaxLength(100); // Giới hạn độ dài chuỗi Name

            builder.Property(c => c.Description)
                   .HasMaxLength(500); // Giới hạn độ dài chuỗi Description (tùy chọn)

            // Các cấu hình bổ sung có thể thêm nếu cần
        }
    }
}
