using API.Models;
using API.Service.user;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Crypto.Generators;
using static System.Net.Mime.MediaTypeNames;
using ResetPasswordRequest = API.Models.ResetPasswordRequest;




namespace API.Controllers.Login
{
    [Route("api/v1/user")]
    [ApiController]

    public class UserController : ControllerBase
    {

        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/v1/user
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var users = await _userService.GetUsersAsync();
            return Ok(users);
        }

        // GET: api/v1/user/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
                return NotFound("User not found.");
            return Ok(user);
        }

        // POST: api/v1/user
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] User newUser)
        {
            // Bạn có thể thêm kiểm tra dữ liệu đầu vào nếu cần
            var result = await _userService.AddUserAsync(newUser);
            if (result)
                return Ok("User added successfully.");
            return BadRequest("Failed to add user.");
        }

        // POST: api/v1/user/register
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRegister userRegister)
        {
            // Kiểm tra xem tên người dùng đã tồn tại chưa
            var existingUser = await _userService.GetUserByUserNameAsync(userRegister.UserName);
            if (existingUser != null)
            {
                return BadRequest(new { message = "Tên tài khoản đã tồn tại." });
            }

            // Kiểm tra email
            var existingEmail = await _userService.GetUserByEmailAsync(userRegister.Email);
            if (existingEmail != null)
            {
                return BadRequest(new { message = "Email đã tồn tại." });
            }

            // Mã hóa và tạo người dùng
            var newUser = new User
            {
                Email = userRegister.Email,
                UserName = userRegister.UserName,
                Password = userRegister.Password,
                Role =  false,
            };

            await _userService.CreateUserAsync(newUser);

            return Ok(new { message = "Đăng ký thành công!" });
        }


        // POST: api/v1/user/login
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLogin userLogin)
        {
            if (string.IsNullOrEmpty(userLogin.UserName) || string.IsNullOrEmpty(userLogin.Password))
            {
                return BadRequest("Tên tài khoản và mật khẩu không được để trống.");
            }

            var user = await _userService.GetUserByUserNameAsync(userLogin.UserName);
            if (user == null)
            {
                return NotFound("Tài khoản không tồn tại.");
            }

            // Kiểm tra mật khẩu (so sánh trực tiếp, nếu bạn muốn tăng tính bảo mật, có thể mã hóa mật khẩu sau này)
            if (userLogin.Password != user.Password)
            {
                return BadRequest("Mật khẩu không đúng.");
            }

            // Trả về thông tin thành công
            return Ok(new
            {
                message = "Đăng nhập thành công",
                user = new
                {
                    user.Id,
                    user.UserName,
                    user.Email,
                    user.Role
                }
            });
        }

        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword([FromBody] Models.ForgotPasswordRequest request)
        {
            var user = await _userService.GetUserByEmailAsync(request.Email);
            if (user == null)
            {
                return BadRequest(new { message = "Email không tồn tại trong hệ thống." });
            }

            // Tạo token khôi phục mật khẩu
            var resetToken = Guid.NewGuid().ToString();
            user.ResetToken = resetToken;
            user.ResetTokenExpiration = DateTime.UtcNow.AddHours(1); // Token có hạn 1 giờ

            await _userService.UpdateUserAsync(user);

            // Gửi email
            var emailSent = await _userService.SendResetPasswordEmailAsync(user.Email, resetToken);
            if (!emailSent)
            {
                return StatusCode(500, "Không thể gửi email khôi phục mật khẩu.");
            }

            return Ok(new { message = "Email khôi phục mật khẩu đã được gửi." });
        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordRequest request)
        {
            try
            {
                // Tìm người dùng theo email
                var user = await _userService.GetUserByEmailAsync(request.Email);
                if (user == null)
                {
                    return BadRequest(new { message = "Người dùng không tồn tại." });
                }

                // Kiểm tra token
                if (user.ResetToken != request.Token || user.ResetTokenExpiration < DateTime.UtcNow)
                {
                    return BadRequest(new { message = "Token không hợp lệ hoặc đã hết hạn." });
                }

                // Kiểm tra mật khẩu mới có trùng với mật khẩu cũ không
                if (user.Password == request.NewPassword)
                {
                    return BadRequest(new { message = "Mật khẩu mới không được trùng với mật khẩu cũ." });
                }

                // Cập nhật mật khẩu mới
                user.Password = request.NewPassword;

                // Xóa token sau khi sử dụng
                user.ResetToken = null;
                user.ResetTokenExpiration = null;

                await _userService.UpdateUserAsync(user);

                return Ok(new { message = "Mật khẩu đã được đặt lại thành công." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Đã xảy ra lỗi trong quá trình xử lý.", error = ex.Message });
            }
        }


    }


}
