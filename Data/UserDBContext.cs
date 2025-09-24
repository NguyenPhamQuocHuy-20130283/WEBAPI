using API.Configuration;
using API.Models;
using API.Seeders;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class UserDBContext(DbContextOptions options) : DbContext(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Apply all configurations
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new AdminConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());  // Add this line
            modelBuilder.ApplyConfiguration(new OrderItemConfiguration());
            modelBuilder.Entity<Order>()
                .HasMany(o => o.OrderItems)
                .WithOne(oi => oi.Order)
                .HasForeignKey(oi => oi.OrderID);

            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Product)
                .WithMany()
                .HasForeignKey(oi => oi.ProductID);
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                entityType.SetTableName(entityType.GetTableName()?.ToLower());
            }

            // Apply any seed data if necessary
            modelBuilder.Seed();
        }

        // DbSet for each entity
        public DbSet<User> User { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }  // Add this line
        public DbSet<Category> Categories { get; set; }
    }
}
