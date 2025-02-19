using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework;

//
public class NorthwindContext : DbContext
{
     protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
     {
          optionsBuilder.UseSqlServer("Server=localhost,1433;Database=Northwind;User Id=sa;Password=macbook/M2Air;TrustServerCertificate=True;");
     }
     
     public DbSet<Product> Products { get; set; }
     public DbSet<Category> Categories { get; set; }
     public DbSet<Customer> Customers { get; set; }
     public DbSet<Order> Orders { get; set; }
}