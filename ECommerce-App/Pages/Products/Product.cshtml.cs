using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce_App.Auth.Services.Interfaces;
using ECommerce_App.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.IdentityModel;

namespace ECommerce_App.Pages.Products  
{
    
    public class ProductModel : PageModel
    {
    public IUserService UserService { get; set; }

    public string id;
   
    [BindProperty]
    public Meal Product { get; set; }
    [BindProperty]
    public CartItem CartInput { get; set; }
    //[BindProperty]
    //public CreateCart NewCart { get; set; }

    private readonly IMeal mealService;

    private readonly ICart cartService;

    

    public ProductModel(IMeal service, ICart newCartService, IUserService uService)
    {
      mealService = service;
      cartService = newCartService;
      UserService = uService;
      CartInput = new CartItem();
      

    }
    
    public async Task OnGet(int id)
        {
            Product = await mealService.GetMeal(id);
        }

        public async Task OnPostAsync()
        {

          var UserId = HttpContext.Request.Cookies["userId"];

          CreateCart cart = await cartService.GetOne(UserId);

          CartItem cartItem = new CartItem()
                {
                    MealId = Product.Id,
                    Price = Product.Price,
                    CreateCartId = cart.Id
                };
            
            CartItem record = await cartService.AddItemToCart( cartItem.MealId, cartItem.Price, cartItem.CreateCartId);


            //CookieOptions cookieoption = new CookieOptions();
            //cookieoption.Expires = new DateTimeOffset(DateTime.Now.AddDays(7));
            //HttpContext.Response.Cookies.Append("Name", Product.name, cookieoption);
            //HttpContext.Response.Cookies.Append("Id", Product.Id.ToString(), cookieoption);
            //HttpContext.Response.Cookies.Append("Price", Product.price.ToString(), cookieoption);


        }
    }
}
