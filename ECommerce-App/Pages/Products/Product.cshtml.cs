using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce_App.Auth.Services.Interfaces;
using ECommerce_App.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerce_App.Pages.Products
{
    public class ProductModel : PageModel
    {
    public string id;

    [BindProperty]
    public Meal Product { get; set; }
    [BindProperty]
    public CartItem CartInput { get; set; }

    private readonly IMeal mealService;

    private readonly ICart cartService;

    

    public ProductModel(IMeal service, ICart newCartService)
    {
      mealService = service;
      cartService = newCartService;
      CartInput = new CartItem();

    }
    
    public async Task OnGet(int id, int mealId, int price)
        {
            Product = await mealService.GetMeal(id);
            //CartInput = await cartService.AddItemToCart(cartId, mealId, price);
        }

        public async Task OnPostAsync()
        {
          CartItem cartItem = new CartItem()
          {
                  mealId = CartInput.mealId,                 
                  price = CartInput.price,
                  userId = CartInput.userId,
                  cartId = CartInput.cartId

          };
            
            CartItem record = await cartService.AddItemToCart( CartInput.mealId, CartInput.price, CartInput.userId, CartInput.cartId);
     

            //CookieOptions cookieoption = new CookieOptions();
            //cookieoption.Expires = new DateTimeOffset(DateTime.Now.AddDays(7));
            //HttpContext.Response.Cookies.Append("Name", Product.name, cookieoption);
            //HttpContext.Response.Cookies.Append("Id", Product.Id.ToString(), cookieoption);
            //HttpContext.Response.Cookies.Append("Price", Product.price.ToString(), cookieoption);


        }
    }
}
