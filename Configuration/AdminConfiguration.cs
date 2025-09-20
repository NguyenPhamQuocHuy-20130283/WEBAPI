using API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Configuration
{
       public class AdminConfiguration : IEntityTypeConfiguration<Admin>
       {
              public void Configure(EntityTypeBuilder<Admin> builder)
              {
                     // Đặt tên bảng
                     builder.ToTable("Admins");

                     // Định nghĩa khóa chính
                     builder.HasKey(a => a.AdminID);

                     // Định nghĩa các thuộc tính
                     builder.Property(a => a.FullName)
                            .IsRequired()
                            .HasMaxLength(150); // Giới hạn độ dài chuỗi FullName

                     builder.Property(a => a.Email)
                            .IsRequired()
                            .HasMaxLength(100); // Giới hạn độ dài chuỗi Email

                     builder.Property(a => a.Password)
                            .IsRequired()
                            .HasMaxLength(256); // Giới hạn độ dài chuỗi Password (tùy chọn)


              }
       }
}
