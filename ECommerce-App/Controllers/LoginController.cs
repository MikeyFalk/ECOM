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
     

        public IActionResult Category()
        {
            return View();
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

    
    }


}
