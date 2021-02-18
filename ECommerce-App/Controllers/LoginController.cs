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
                new Category(){name = "Vegan"},
                new Category(){name = "Vegetarian", mealName= "rice pilaf", type = "Vegetarian"},
                new Category(){name = "Pescatarian"},
                new Category(){name = "Dessert"},
                new Category(){name = "Comfort"}
            };
                return View(categories);
            }
     

        public IActionResult Category(string name, string type)
        {
            Category category = new Category()
            {
              name = name,
              type = type
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

            var user = await userService.Register(data, this.ModelState);
            if (ModelState.IsValid)
            {
                return Redirect("/login");
            }
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

        //[Authorize(Policy = "read")]
        public async Task<ActionResult<UserDTO>> Profile()
        {
          UserDTO user = await userService.GetUser(this.User);
          return View(user);
        }

    public IActionResult Meal(string name, int price, string ingredients, string nutrition, string type)

    {
      List<Meal> meal = new List<Meal>()
            {
            new Meal() { name = "Vegan Chili", price = 12, ingredients = "beans, tomatoes, olive oil, tofu crumbles, spices, garlic", nutrition = "healthy", type = "vegan" },
            new Meal() { name = "Pan Fried Tofu w/ veggies", price = 14, ingredients = "tofu, olive oil, spices, garlic, green beans, potatoes", nutrition = "healthy", type = "vegan" },
            new Meal() { name = "Vegan Pizza", price = 15, ingredients = "olives, tomato sauce, olive oil, tofu crumbles, spices, garlic, vegan cheese", nutrition = "healthy", type = "vegan" },
            new Meal() { name = "Salmon with veggies", price = 18, ingredients = "Salmon filets, cherry tomatoes, olive oil, asparagus, spices, garlic", nutrition = "healthy", type = "pescatarian" },
            new Meal() { name = "Shrimp Fried Rice", price = 15, ingredients = "Shrimp, rice, olive oil, egg, spices, garlic, carrots, peas", nutrition = "healthy", type = "pescatarian" },
            new Meal() { name = "Cod with rice pilaf and veggies", price = 17, ingredients = "Cod, rice pilaf, olive oil, green beans, spices, garlic", nutrition = "healthy", type = "pescatarian" },
            new Meal() { name = "Tiramisu", price = 10, ingredients = "espresso, ladyfingers, custard, cream, cocoa powder", nutrition = "not healthy", type = "desert" },
            new Meal() { name = "Chocolate Cake", price = 10, ingredients = "chocolate, flour, sugar, eggs", nutrition = "not healthy", type = "desert" },
            new Meal() { name = "Lasagna", price = 20 , ingredients = "cheese, tomatoes, Italian sausage, noodles, spices, garlic", nutrition = "not healthy", type = "comfort" }
        };

      return View(meal);
    }
    public IActionResult MealsByCategory(string mealname)
    {
      List<MealsByCategory> mealsByCategory = new List<MealsByCategory>()
            {
                new MealsByCategory(){mealName = "Vegan Chili"}
            };
      return View(mealsByCategory);
    }


  }


}
