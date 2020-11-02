using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using StoreDB.Models;

namespace StoreDB
{
    public class StoreContext : DbContext
    {
        public DbSet<Location> StoreLocations {get; set;}
        public DbSet<Customer> Customers {get; set;}
        public DbSet<Cart> Carts {get; set;}
        public DbSet<InvItem> InvItems {get; set;}
        public DbSet<CartItem> CartItems {get; set;}
        public DbSet<OrderItem> OrderItems {get; set;}
        public DbSet<Product> Products {get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if( !optionsBuilder.IsConfigured )
            {
                var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();

                var connectionString = configuration.GetConnectionString("StoreDB"); //refers to the specific string in appsettings.json
                optionsBuilder.UseNpgsql(connectionString); //connects the database
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InvItem>().HasKey(i => new { i.Product, i.LocationId });

            modelBuilder.Entity<CartItem>().HasKey(c => new { c.Product, c.CartId });
            
            modelBuilder.Entity<OrderItem>().HasKey(o => new { o.Product, o.OrderId });
        }
    }
}