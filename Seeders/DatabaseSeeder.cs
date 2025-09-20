using API.Models;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace API.Seeders
{
    public static class DatabaseSeeder
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            _ = modelBuilder.Entity<User>().HasData(
                new User()
                {
                    Id = 1,
                    Email = "chihtt123@gmail.com",
                    UserName = "chi",
                    Password = "123",
                    Role = true
                }

                );
        }
    }
}
