using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce_App.Auth.Services.Interfaces;
using ECommerce_App.Models;
using ECommerce_App.Pages.Products;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerce_App.Pages.Cart
{
    public class CartModel : PageModel
    {   [BindProperty]
        public CartModel Cart { get; set; }
        [BindProperty]
        public string Name { get; set; }
        [BindProperty]
        public int Price { get; set; }
        [BindProperty]
        public int Id { get; set; }
        [BindProperty]
        public int Quantity { get; set; }

        // navigation properties to our models and interfaces below
        private readonly ICart cartService;
        private readonly IMeal mealService;
        [BindProperty]
        public CartItem CheckoutCart { get; set; }
        [BindProperty]
        public List<CartItem> Checkout { get; set; }

    public CartModel(ICart newCartService, IMeal newMealService)
    {
      cartService = newCartService;
      mealService = newMealService;
      CheckoutCart = new CartItem();
       
    }
    /// <summary>
    /// Our on get method here will grab the user id that is stored in the cookies
    /// </summary>
    /// <returns>the cart items that are associated with the user's cart </returns>
    public async Task OnGet()
        {
            String UserId = HttpContext.Request.Cookies["UserId"];  
            Checkout = await cartService.GetCartItems(UserId); 
        }
    /// <summary>
    /// On post method takes care of setting cookies for new users that register
    /// </summary>
        public void OnPost()
        {
            CookieOptions cookieOptions = new CookieOptions();
            cookieOptions.Expires = new DateTimeOffset(DateTime.Now.AddDays(7));
            HttpContext.Response.Cookies.Append("Name", Name, cookieOptions);
            HttpContext.Response.Cookies.Append("Id", Id.ToString(), cookieOptions);
            HttpContext.Response.Cookies.Append("Quantity", Quantity.ToString(), cookieOptions);
            HttpContext.Response.Cookies.Append("Price", Price.ToString(), cookieOptions);

        }
    }
}

           