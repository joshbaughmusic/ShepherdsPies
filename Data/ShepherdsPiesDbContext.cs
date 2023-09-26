using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using ShepherdsPies.Models;
using Microsoft.AspNetCore.Identity;

namespace ShepherdsPies.Data;
public class ShepherdsPiesDbContext : IdentityDbContext<IdentityUser>
{
    private readonly IConfiguration _configuration;

    public DbSet<Employee> Employees { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Size> Sizes { get; set; }
    public DbSet<Cheese> Cheeses { get; set; }
    public DbSet<Sauce> Sauces { get; set; }
    public DbSet<Topping> Toppings { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Pizza> Pizzas { get; set; }
    public DbSet<PizzaTopping> PizzaToppings { get; set; }

    public ShepherdsPiesDbContext(DbContextOptions<ShepherdsPiesDbContext> context, IConfiguration config) : base(context)
    {
        _configuration = config;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
        {
            Id = "c3aaeb97-d2ba-4a53-a521-4eea61e59b35",
            Name = "Admin",
            NormalizedName = "admin"
        });

        modelBuilder.Entity<IdentityUser>().HasData(new IdentityUser
        {
            Id = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
            UserName = "Administrator",
            Email = "admina@strator.comx",
            PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["AdminPassword"])
        });

        modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
        {
            RoleId = "c3aaeb97-d2ba-4a53-a521-4eea61e59b35",
            UserId = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f"
        });
        modelBuilder.Entity<Employee>().HasData(new Employee
        {
            Id = 1,
            IdentityUserId = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
            FirstName = "Admina",
            LastName = "Strator",
            Address = "101 Main Street",
            Email = "admina@strator.comx",

        });

        // Customers
            modelBuilder.Entity<Customer>().HasData(
                new Customer { Id = 1, FirstName = "John", LastName = "Doe", Address = "123 Main St", Phone = 1234567890 },
                new Customer { Id = 2, FirstName = "Jane", LastName = "Smith", Address = "456 Elm St", Phone = 2345678901 },
                new Customer { Id = 3, FirstName = "Alice", LastName = "Johnson", Address = "789 Oak St", Phone = 3456789012 },
                new Customer { Id = 4, FirstName = "Bob", LastName = "Williams", Address = "101 Pine St", Phone = 4567890123 },
                new Customer { Id = 5, FirstName = "Eve", LastName = "Brown", Address = "222 Birch St", Phone = 5678901234 }
            );

            // Sizes
            modelBuilder.Entity<Size>().HasData(
                new Size { Id = 1, Name = "Small (10\")", Price = 10.00m },
                new Size { Id = 2, Name = "Medium (14\")", Price = 12.00m },
                new Size { Id = 3, Name = "Large (18\")", Price = 15.00m }
            );

            // Cheeses
            modelBuilder.Entity<Cheese>().HasData(
                new Cheese { Id = 1, Name = "Buffalo Mozzarella" },
                new Cheese { Id = 2, Name = "Four Cheese" },
                new Cheese { Id = 3, Name = "Vegan" },
                new Cheese { Id = 4, Name = "None (cheeseless)" }
            );

            // Sauces
            modelBuilder.Entity<Sauce>().HasData(
                new Sauce { Id = 1, Name = "Marinara" },
                new Sauce { Id = 2, Name = "Arrabbiata" },
                new Sauce { Id = 3, Name = "Garlic White" },
                new Sauce { Id = 4, Name = "None (sauceless pizza)" }
            );

            // Toppings
            modelBuilder.Entity<Topping>().HasData(
                new Topping { Id = 1, Name = "Sausage", Price = 0.50m },
                new Topping { Id = 2, Name = "Pepperoni", Price = 0.50m },
                new Topping { Id = 3, Name = "Mushroom", Price = 0.50m },
                new Topping { Id = 4, Name = "Onion", Price = 0.50m },
                new Topping { Id = 5, Name = "Green Pepper", Price = 0.50m },
                new Topping { Id = 6, Name = "Black Olive", Price = 0.50m },
                new Topping { Id = 7, Name = "Basil", Price = 0.50m },
                new Topping { Id = 8, Name = "Extra Cheese", Price = 0.50m }
            );

            // Orders
            modelBuilder.Entity<Order>().HasData(
                new Order { Id = 1, EmployeeId = 1, DriverId = 1, CustomerId = 1, Date = new DateTime(2023, 8, 26), Delivery = true, Tip = 5.00m },
                new Order { Id = 2, EmployeeId = 1, DriverId = null, CustomerId = 2, Date = new DateTime(2023, 8, 22), Delivery = false, Tip = null },
                new Order { Id = 3, EmployeeId = 1, DriverId = 1, CustomerId = 3, Date = new DateTime(2023, 8, 24), Delivery = true, Tip = 3.00m },
                new Order { Id = 4, EmployeeId = 1, DriverId = null, CustomerId = 4, Date = new DateTime(2023, 9, 19), Delivery = false, Tip = 2.00m },
                new Order { Id = 5, EmployeeId = 1, DriverId = null, CustomerId = 5, Date = new DateTime(2023, 9, 24), Delivery = true, Tip = 3.00m }
            );

            // Pizzas
            modelBuilder.Entity<Pizza>().HasData(
                new Pizza { Id = 1, OrderId = 1, SizeId = 1, CheeseId = 1, SauceId = 1 },
                new Pizza { Id = 2, OrderId = 1, SizeId = 1, CheeseId = 2, SauceId = 3 },
                new Pizza { Id = 3, OrderId = 2, SizeId = 3, CheeseId = 2, SauceId = 1 },
                new Pizza { Id = 4, OrderId = 3, SizeId = 1, CheeseId = 4, SauceId = 2 },
                new Pizza { Id = 5, OrderId = 4, SizeId = 2, CheeseId = 2, SauceId = 1 },
                new Pizza { Id = 6, OrderId = 4, SizeId = 3, CheeseId = 3, SauceId = 2 },
                new Pizza { Id = 7, OrderId = 5, SizeId = 3, CheeseId = 1, SauceId = 4 }
            );

            // Pizza Toppings
            modelBuilder.Entity<PizzaTopping>().HasData(
                new PizzaTopping { Id = 1, PizzaId = 1, ToppingId = 2 },
                new PizzaTopping { Id = 2, PizzaId = 1, ToppingId = 1 },
                new PizzaTopping { Id = 3, PizzaId = 2, ToppingId = 4 },
                new PizzaTopping { Id = 4, PizzaId = 2, ToppingId = 6 },
                new PizzaTopping { Id = 5, PizzaId = 3, ToppingId = 7 },
                new PizzaTopping { Id = 6, PizzaId = 4, ToppingId = 5 },
                new PizzaTopping { Id = 7, PizzaId = 4, ToppingId = 8 },
                new PizzaTopping { Id = 8, PizzaId = 4, ToppingId = 2 },
                new PizzaTopping { Id = 9, PizzaId = 5, ToppingId = 3 },
                new PizzaTopping { Id = 10, PizzaId = 6, ToppingId = 1 },
                new PizzaTopping { Id = 11, PizzaId = 6, ToppingId = 3 },
                new PizzaTopping { Id = 12, PizzaId = 7, ToppingId = 5 }
            );
    }
}