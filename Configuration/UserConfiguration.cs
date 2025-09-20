using API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Configuration
{
       public class UserConfiguration : IEntityTypeConfiguration<User>
       {
              public void Configure(EntityTypeBuilder<User> builder)
              {
                     // Đặt tên bảng
                     builder.ToTable("User");

                     // Định nghĩa khóa chính
                     builder.HasKey(u => u.Id);



                     builder.Property(u => u.Email)
                            .IsRequired()
                            .HasMaxLength(100); // Giới hạn độ dài chuỗi Email

                     builder.Property(u => u.UserName)
                            .IsRequired()
                            .HasMaxLength(50); // Giới hạn độ dài chuỗi UserName

                     builder.Property(u => u.Password)
                            .IsRequired()
                            .HasMaxLength(256); // Giới hạn độ dài chuỗi Password (tùy chọn)

                     builder.Property(u => u.Role)
                            .IsRequired(); // Xác định vai trò là bắt buộc

              }
       }
}
