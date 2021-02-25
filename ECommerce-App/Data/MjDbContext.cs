using ECommerce_App.Auth.Models;
using ECommerce_App.Auth.Models.DTO;
using ECommerce_App.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ECommerce_App.Data
{
  public class MjDbContext : IdentityDbContext<AuthUser>
  {

    public DbSet<Category> Category { get; set; }
    public DbSet<Meal> Meal { get; set; }
    public DbSet<CreateCart> Cart { get; set; }
    //public DbSet<CartItem> CartItem { get; set; }

    public MjDbContext(DbContextOptions options) : base(options)
    {

    }
    
    
        
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);
      SeedRole(modelBuilder, "Administrator", "read", "create", "update", "delete");
      SeedRole(modelBuilder, "Editor", "read", "create", "update");
      SeedRole(modelBuilder, "Guest", "read");
        //This seeds meals into the meal table 
       modelBuilder.Entity<Meal>().HasData(
        new Meal() { Id = 1, name = "Vegan Chili", price = 12, ingredients = "beans, tomatoes, olive oil, tofu crumbles, spices, garlic", nutrition = "healthy", type = "vegan" },
        new Meal() { Id = 2, name = "Pan Fried Tofu w/ veggies", price = 14, ingredients = "tofu, olive oil, spices, garlic, green beans, potatoes", nutrition = "healthy", type = "vegan" },
        new Meal() { Id = 3, name = "Vegan Pizza", price = 15, ingredients = "olives, tomato sauce, olive oil, tofu crumbles, spices, garlic, vegan cheese", nutrition = "healthy", type = "vegan" },

        new Meal() { Id = 4, name = "Salmon with veggies", price = 18, ingredients = "Salmon filets, cherry tomatoes, olive oil, asparagus, spices, garlic", nutrition = "healthy", type = "pescatarian" },
        new Meal() { Id = 5, name = "Shrimp Fried Rice", price = 15, ingredients = "Shrimp, rice, olive oil, egg, spices, garlic, carrots, peas", nutrition = "healthy", type = "pescatarian" },
        new Meal() { Id = 6, name = "Cod with rice pilaf and veggies", price = 17, ingredients = "Cod, rice pilaf, olive oil, green beans, spices, garlic", nutrition = "healthy", type = "pescatarian" },

        new Meal() { Id = 7, name = "Tiramisu", price = 10, ingredients = "espresso, ladyfingers, custard, cream, cocoa powder", nutrition = "not healthy", type = "desert" },
        new Meal() { Id = 8, name = "Chocolate Cake", price = 10, ingredients = "chocolate, flour, sugar, eggs", nutrition = "not healthy", type = "desert" },
        new Meal() { Id = 9, name = "Lasagna", price = 20, ingredients = "cheese, tomatoes, Italian sausage, noodles, spices, garlic", nutrition = "not healthy", type = "comfort" }


         );
      // join tables below 
      modelBuilder.Entity<MealsByCategory>().HasKey(MealsByCategory => new { MealsByCategory.MealId, MealsByCategory.CategoryId });
      modelBuilder.Entity<CartsByUser>().HasKey(CartsByUser => new { CartsByUser.CartId, CartsByUser.UserId });
      modelBuilder.Entity<CartItem>().HasKey(CartItem => new { CartItem.cartId, CartItem.productId });

      //this seed categories into the category table
      modelBuilder.Entity<Category>().HasData(
                new Category() { id = 1, name = "Vegan"},
                new Category() { id = 2, name = "Vegetarian"},
                new Category() { id = 3, name = "Pescatarian" },
                new Category() { id = 4, name = "Dessert" },
                new Category() { id = 5, name = "Comfort" }

                );            
    }
    private int nextId = 1;
    private void SeedRole(ModelBuilder modelBuilder, string roleName, params string[] permissions)
    {
      var role = new IdentityRole
      {
        Id = roleName.ToLower(),
        Name = roleName,
        NormalizedName = roleName.ToUpper(),
        ConcurrencyStamp = Guid.Empty.ToString()

      };

      modelBuilder.Entity<IdentityRole>().HasData(role);
      var roleClaims = permissions.Select(permission => new IdentityRoleClaim<string>
      {
        Id = nextId++,
        RoleId = role.Id,
        ClaimType = "permissions",
        ClaimValue = permission
      }).ToArray();
      modelBuilder.Entity<IdentityRoleClaim<string>>().HasData(roleClaims);
    }
  }
 
}
