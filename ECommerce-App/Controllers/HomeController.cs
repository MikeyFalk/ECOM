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
                name = name,
                type = type
            };

            return View(category);
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

        public IActionResult Meal(string name, int price, string Ingredients, string Nutrition, string type)

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
