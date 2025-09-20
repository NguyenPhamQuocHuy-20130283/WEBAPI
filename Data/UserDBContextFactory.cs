using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace API.Data
{
    public class UserDBContextFactory : IDesignTimeDbContextFactory<UserDBContext>
    {
        public UserDBContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configurationRoot = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json").Build();


            var connectionString = configurationRoot.GetConnectionString("UserDataBase");

            var optionBuilder = new DbContextOptionsBuilder<UserDBContext>();
            optionBuilder.UseSqlServer(connectionString);
            return new UserDBContext(optionBuilder.Options);
        }
    }
}
