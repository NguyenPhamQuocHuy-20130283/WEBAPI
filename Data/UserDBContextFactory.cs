using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

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
            optionBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            return new UserDBContext(optionBuilder.Options);
        }
    }
}
