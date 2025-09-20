namespace API.Models
{
    public class User
    {

        public int Id { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool Role { get; set; }

        // Thuộc tính cho quên mật khẩu
        public string? ResetToken { get; set; }
        public DateTime? ResetTokenExpiration { get; set; }
    }

};



