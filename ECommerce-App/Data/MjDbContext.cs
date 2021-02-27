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
    public DbSet<CreateCart> CreateCart { get; set; }
    public DbSet<CartItem> CartItem { get; set; }

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
        new Meal() { Id = 1, Name = "Vegan Chili", Price = 12, Ingredients = "beans, tomatoes, olive oil, tofu crumbles, spices, garlic", Nutrition = "healthy", Type = "vegan" },
        new Meal() { Id = 2, Name = "Pan Fried Tofu w/ veggies", Price = 14, Ingredients = "tofu, olive oil, spices, garlic, green beans, potatoes", Nutrition = "healthy", Type = "vegan" },
        new Meal() { Id = 3, Name = "Vegan Pizza", Price = 15, Ingredients = "olives, tomato sauce, olive oil, tofu crumbles, spices, garlic, vegan cheese", Nutrition = "healthy", Type = "vegan" },

        new Meal() { Id = 4, Name = "Salmon with veggies", Price = 18, Ingredients = "Salmon filets, cherry tomatoes, olive oil, asparagus, spices, garlic", Nutrition = "healthy", Type = "pescatarian" },
        new Meal() { Id = 5, Name = "Shrimp Fried Rice", Price = 15, Ingredients = "Shrimp, rice, olive oil, egg, spices, garlic, carrots, peas", Nutrition = "healthy", Type = "pescatarian" },
        new Meal() { Id = 6, Name = "Cod with rice pilaf and veggies", Price = 17, Ingredients = "Cod, rice pilaf, olive oil, green beans, spices, garlic", Nutrition = "healthy", Type = "pescatarian" },

        new Meal() { Id = 7, Name = "Tiramisu", Price = 10, Ingredients = "espresso, ladyfingers, custard, cream, cocoa powder", Nutrition = "not healthy", Type = "desert" },
        new Meal() { Id = 8, Name = "Chocolate Cake", Price = 10, Ingredients = "chocolate, flour, sugar, eggs", Nutrition = "not healthy", Type = "desert" },
        new Meal() { Id = 9, Name = "Lasagna", Price = 20, Ingredients = "cheese, tomatoes, Italian sausage, noodles, spices, garlic", Nutrition = "not healthy", Type = "comfort" }


         );
      // join tables below 
      
      modelBuilder.Entity<CartItem>().HasKey(c => new { c.MealId, c.CreateCartId });

            modelBuilder.Entity<MealsByCategory>().HasKey(MealsByCategory => new { MealsByCategory.MealId, MealsByCategory.CategoryId });



            //this seed categories into the category table
            modelBuilder.Entity<Category>().HasData(
                new Category() { Id = 1, Name = "Vegan"},
                new Category() { Id = 2, Name = "Vegetarian"},
                new Category() { Id = 3, Name = "Pescatarian" },
                new Category() { Id = 4, Name = "Dessert" },
                new Category() { Id = 5, Name = "Comfort" }

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
