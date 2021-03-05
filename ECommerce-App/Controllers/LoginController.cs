using ECommerce_App.Auth.Models.DTO;
using ECommerce_App.Auth.Services.Interfaces;
using ECommerce_App.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce_App.Controllers
{
    public class LoginController : Controller
    {
        private IUserService userService;

        public LoginController(IUserService service)
        {
            userService = service;
        }
        public IActionResult Index()
        {
            return View();
        }

        
        
       public IActionResult Categories(string name, string type)
        {


                List<Category> categories = new List<Category>()
            {
                new Category(){Name = "Vegan"},
                new Category(){Name = "Vegetarian", MealName= "rice pilaf", Type = "Vegetarian"},
                new Category(){Name = "Pescatarian"},
                new Category(){Name = "Dessert"},
                new Category(){Name = "Comfort"}
            };
                return View(categories);
            }
     

        public IActionResult Category(string name, string type)
        {
            Category category = new Category()
            {
              Name = name,
              Type = type
            };
            return View(category);
        }



        public IActionResult Error()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult<UserDTO>> Authenticate(LoginData data)
        {
            var user = await userService.Authenticate(data.Username, data.Password);
            if (user == null)
            {
                return Redirect("/login");
            }
            return Redirect("/login/profile");
        }

        [HttpPost]
        public async Task<ActionResult<UserDTO>> Register(RegisterDTO data)
        {
            data.Roles = new List<string>() { "guest" };

            var user = await userService.Register(data);
        
            
            return Redirect("/login/welcome");
        }

        public IActionResult Signup()
        {
          return View();
        }

        public IActionResult Welcome()
        {
                return View();
        }

        //[Authorize(Roles = "administrator")]
        public async Task<ActionResult<UserDTO>> Profile()
        {
          UserDTO user = await userService.GetUser(this.User);
          return View(user);
        }

    public IActionResult Meal(string name, int price, string ingredients, string nutrition, string type)

    {
      List<Meal> meal = new List<Meal>()
            {
            new Meal() { Id = 1, Name = "Vegan Chili", Price = 12, Ingredients = "beans, tomatoes, olive oil, tofu crumbles, spices, garlic", Nutrition = "healthy", Type = "vegan" },
        new Meal() { Id = 2, Name = "Pan Fried Tofu w/ veggies", Price = 14, Ingredients = "tofu, olive oil, spices, garlic, green beans, potatoes", Nutrition = "healthy", Type = "vegan" },
        new Meal() { Id = 3, Name = "Vegan Pizza", Price = 15, Ingredients = "olives, tomato sauce, olive oil, tofu crumbles, spices, garlic, vegan cheese", Nutrition = "healthy", Type = "vegan" },

        new Meal() { Id = 4, Name = "Salmon with veggies", Price = 18, Ingredients = "Salmon filets, cherry tomatoes, olive oil, asparagus, spices, garlic", Nutrition = "healthy", Type = "pescatarian" },
        new Meal() { Id = 5, Name = "Shrimp Fried Rice", Price = 15, Ingredients = "Shrimp, rice, olive oil, egg, spices, garlic, carrots, peas", Nutrition = "healthy", Type = "pescatarian" },
        new Meal() { Id = 6, Name = "Cod with rice pilaf and veggies", Price = 17, Ingredients = "Cod, rice pilaf, olive oil, green beans, spices, garlic", Nutrition = "healthy", Type = "pescatarian" },

        new Meal() { Id = 7, Name = "Tiramisu", Price = 10, Ingredients = "espresso, ladyfingers, custard, cream, cocoa powder", Nutrition = "not healthy", Type = "desert" },
        new Meal() { Id = 8, Name = "Chocolate Cake", Price = 10, Ingredients = "chocolate, flour, sugar, eggs", Nutrition = "not healthy", Type = "desert" },
        new Meal() { Id = 9, Name = "Lasagna", Price = 20, Ingredients = "cheese, tomatoes, Italian sausage, noodles, spices, garlic", Nutrition = "not healthy", Type = "comfort" }
        };

      return View(meal);
    }
    public IActionResult MealsByCategory()
    {
      return View();
    }


  }


}
