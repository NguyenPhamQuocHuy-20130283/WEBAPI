using API.Data;
using API.Models;
using Microsoft.EntityFrameworkCore;
using SendGrid; // Dùng SendGrid
using SendGrid.Helpers.Mail; // Gửi email qua SendGrid
using System.Net;
using System.Net.Mail;


namespace API.Service.user
{
    public class UserService : IUserService
    {
        private readonly UserDBContext _userDBContext;

        public UserService(UserDBContext userDBContext)
        {
            _userDBContext = userDBContext;
        }

        // Lấy danh sách tất cả người dùng
        public async Task<List<User>> GetUsersAsync()
        {
            return await _userDBContext.User.ToListAsync();
        }

        // Lấy người dùng theo ID
        public async Task<User> GetUserByIdAsync(int userId)
        {
            return await _userDBContext.User.FirstOrDefaultAsync(u => u.Id == userId);
        }

        // Lấy người dùng theo tên người dùng (username)
        public async Task<User> GetUserByUserNameAsync(string userName)
        {
            // Tìm người dùng theo username
            return await _userDBContext.User.FirstOrDefaultAsync(u => u.UserName == userName);
        }

        // Thêm người dùng mới
        public async Task<bool> AddUserAsync(User newUser)
        {
            try
            {
                _userDBContext.User.Add(newUser);
                await _userDBContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding user: {ex.Message}");
                return false;
            }
        }

        public async Task<User> CreateUserAsync(User user)
        {
            try
            {
                // Thêm người dùng vào DbContext
                _userDBContext.User.Add(user);

                // Lưu thay đổi vào cơ sở dữ liệu
                await _userDBContext.SaveChangesAsync();

                // Trả về người dùng vừa được tạo
                return user;
            }
            catch (Exception ex)
            {
                // Xử lý lỗi (ví dụ: ghi log hoặc trả về null)
                Console.WriteLine($"Error creating user: {ex.Message}");
                return null;  // Trả về null nếu có lỗi xảy ra
            }
        }

        // Cập nhật thông tin người dùng
        public async Task<bool> UpdateUserAsync(User user)
        {
            try
            {
                _userDBContext.User.Update(user);
                await _userDBContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating user: {ex.Message}");
                return false;
            }
        }
        // Xóa người dùng
        public async Task<bool> DeleteUserAsync(int userId)
        {
            try
            {
                var userToDelete = await _userDBContext.User.FirstOrDefaultAsync(u => u.Id == userId);
                if (userToDelete == null) return false;

                _userDBContext.User.Remove(userToDelete);
                await _userDBContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _userDBContext.User.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<bool> SendResetPasswordEmailAsync(string email, string resetToken)
        {
            try
            {
                var smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential("chihtt1234@gmail.com", "limj cuov rrtf sxzm"),
                    EnableSsl = true,
                };

                var mailMessage = new MailMessage
                {
                    From = new MailAddress("chihtt1234@gmail.com", "WATCH STORE"),
                    Subject = "Khôi phục mật khẩu",
                    Body = $"<p>Sử dụng mã sau để đặt lại mật khẩu:</p><p><b>{resetToken}</b></p>",
                    IsBodyHtml = true,
                };
                mailMessage.To.Add(email);

                await smtpClient.SendMailAsync(mailMessage);
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
