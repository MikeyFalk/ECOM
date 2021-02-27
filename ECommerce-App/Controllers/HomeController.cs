using ECommerce_App.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce_App.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            /*if (zip != null)

            {
                CookieOptions cookieOptions = new CookieOptions();
                cookieOptions.Expires = new DateTimeOffset(DateTime.Now.AddDays(7));
               HttpContext.Response.Cookies.Append("zipCode", zip, cookieOptions);
            }
            */
            return View();

        }
        public IActionResult Weather()
        {
            string zip = HttpContext.Request.Cookies["zipCode"];
            ViewData["zip"] = zip;
            return View();
        }


        //public void SetCookie(string key, string value, int? expireTime)
        //{
         //   CookieOptions option = new CookieOptions();
        //}

       public IActionResult Category(string name, string type)
        {
            Category category = new Category()
            {
                Name = name,
                Type = type
            };

            return View(category);
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

        public IActionResult Meal(string name, int price, string Ingredients, string Nutrition, string type)

        {
            List<Meal> meal = new List<Meal>()
            {
            new Meal() { Name = "Vegan Chili", Price = 12, Ingredients = "beans, tomatoes, olive oil, tofu crumbles, spices, garlic", Nutrition = "healthy", Type = "vegan" },
            new Meal() { Name = "Pan Fried Tofu w/ veggies", Price = 14, Ingredients = "tofu, olive oil, spices, garlic, green beans, potatoes", Nutrition = "healthy", Type = "vegan" },
            new Meal() { Name = "Vegan Pizza", Price = 15, Ingredients = "olives, tomato sauce, olive oil, tofu crumbles, spices, garlic, vegan cheese", Nutrition = "healthy", Type = "vegan" },
            new Meal() { Name = "Salmon with veggies", Price = 18, Ingredients = "Salmon filets, cherry tomatoes, olive oil, asparagus, spices, garlic", Nutrition = "healthy", Type = "pescatarian" },
            new Meal() { Name = "Shrimp Fried Rice", Price = 15, Ingredients = "Shrimp, rice, olive oil, egg, spices, garlic, carrots, peas", Nutrition = "healthy", Type = "pescatarian" },
            new Meal() { Name = "Cod with rice pilaf and veggies", Price = 17, Ingredients = "Cod, rice pilaf, olive oil, green beans, spices, garlic", Nutrition = "healthy", Type = "pescatarian" },
            new Meal() { Name = "Tiramisu", Price = 10, Ingredients = "espresso, ladyfingers, custard, cream, cocoa powder", Nutrition = "not healthy", Type = "desert" },
            new Meal() { Name = "Chocolate Cake", Price = 10, Ingredients = "chocolate, flour, sugar, eggs", Nutrition = "not healthy", Type = "desert" },
            new Meal() { Name = "Lasagna", Price = 20 , Ingredients = "cheese, tomatoes, Italian sausage, noodles, spices, garlic", Nutrition = "not healthy", Type = "comfort" }
        };

          return View(meal);
        }
        public IActionResult MealsByCategory()
        {
      //List<MealsByCategory> mealsByCategory = new List<MealsByCategory>()
            //{
            //    new MealsByCategory(){mealName = "Vegan Chili"}
            //};
      return View();
        }


        
    }
}
