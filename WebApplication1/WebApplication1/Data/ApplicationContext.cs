using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data;

public class ApplicationContext : DbContext
{
    protected ApplicationContext()
    {
    }

    public ApplicationContext(DbContextOptions options) : base(options)
    {
    }
    
    public DbSet<Accounts> AccountsEnumerable { get; set; }
    public DbSet<Categories> CategoriesEnumerable  { get; set; }
    public DbSet<Products> ProductsEnumerable { get; set; }
    public DbSet<Products_Categories> ProductsCategoriesEnumerable  { get; set; }
    public DbSet<Roles> RolesEnumerable  { get; set; }
    public DbSet<ShoppingCarts> ShoppingCartsEnumerable  { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Seeding Roles
        modelBuilder.Entity<Roles>().HasData(
            new Roles { PK_role = 1, Name = "Admin" },
            new Roles { PK_role = 2, Name = "User" }
        );

        // Seeding Accounts
        modelBuilder.Entity<Accounts>().HasData(
            new Accounts { PK_account = 1, FK_Role = 1, First_Name = "John", Last_Name = "Doe", Email = "john.doe@example.com", Phone = "123456789" },
            new Accounts { PK_account = 2, FK_Role = 2, First_Name = "Jane", Last_Name = "Smith", Email = "jane.smith@example.com", Phone = "987654321" }
        );

        // Seeding Categories
        modelBuilder.Entity<Categories>().HasData(
            new Categories { PK_category = 1, Name = "Electronics" },
            new Categories { PK_category = 2, Name = "Books" }
        );

        // Seeding Products
        modelBuilder.Entity<Products>().HasData(
            new Products { PK_Product = 1, Name = "Laptop", weight = 2.5, width = 30, height = 2, depth = 20 },
            new Products { PK_Product = 2, Name = "Smartphone", weight = 0.2, width = 7, height = 0.7, depth = 15 }
        );

        // Seeding Products_Categories
        modelBuilder.Entity<Products_Categories>().HasData(
            new Products_Categories { FK_Product = 1, FK_Category = 1 },
            new Products_Categories { FK_Product = 2, FK_Category = 1 }
        );

        // Seeding ShoppingCarts
        modelBuilder.Entity<ShoppingCarts>().HasData(
            new ShoppingCarts { FK_Account = 1, FK_Product = 1, amount = 1 },
            new ShoppingCarts { FK_Account = 2, FK_Product = 2, amount = 2 }
        );
    }
    


}