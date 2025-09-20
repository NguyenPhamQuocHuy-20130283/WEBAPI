using API.Controllers.Login;
using API.Models;

namespace API.Service.user
{
    public interface IUserService
    {
        Task<List<User>> GetUsersAsync();
        Task<User> GetUserByIdAsync(int userId);  // Added for retrieving a specific user by ID
        Task<bool> AddUserAsync(User newUser);
        Task<bool> UpdateUserAsync(User user);
        Task<bool> DeleteUserAsync(int userId);  // Accepts user ID to delete

        Task<User> GetUserByUserNameAsync(string userName);

        Task<User> CreateUserAsync(User user);

        Task<User> GetUserByEmailAsync(string email);
        Task<bool> SendResetPasswordEmailAsync(string email, string resetToken);


    }
}
