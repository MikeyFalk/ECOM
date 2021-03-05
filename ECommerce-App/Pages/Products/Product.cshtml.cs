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
    
    private readonly IMeal mealService;

    private readonly ICart cartService;

    

    public ProductModel(IMeal service, ICart newCartService, IUserService uService)
    {
      mealService = service;
      cartService = newCartService;
      UserService = uService;
      CartInput = new CartItem();
    }
    
    /// <summary>
    /// On get, we are grabbing the specific product id to be displayed
    /// </summary>
    /// <param name="id"></param>
    /// <returns>product that the user selected</returns>
    public async Task OnGet(int id)
        {
            Product = await mealService.GetMeal(id);
        }
        /// <summary>
        /// This was one trickier, but on post we attach the user id to the cart. So when a new user is created, so is a cart and by doing so when a user clicks on add to cart, it attaches to the specific ids.
        /// </summary>
        /// <returns>Item in cart </returns>
        public async Task OnPostAsync()
        {

          var UserId = HttpContext.Request.Cookies["userId"];

          CreateCart cart = await cartService.GetOne(UserId);

          CartItem cartItem = new CartItem()
                {
                    MealId = Product.Id,
                    Price = Product.Price,
                    Quantity = cart.Quantity, 
                    CreateCartId = cart.Id
                };
            
            CartItem record = await cartService.AddItemToCart( cartItem.MealId, cartItem.Price, cartItem.Quantity, cartItem.CreateCartId);
            
        }
    }
}
