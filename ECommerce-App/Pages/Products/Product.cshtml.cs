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

    private readonly IMeal mealService;

    public ProductModel(IMeal service)
    {
      mealService = service;
    }
    public async Task OnGet(int id)
        {
            Product = await mealService.GetMeal(id);
        }

        public void OnPost()
        {
            CookieOptions cookieoption = new CookieOptions();
            cookieoption.Expires = new DateTimeOffset(DateTime.Now.AddDays(7));
            HttpContext.Response.Cookies.Append("Name", Product.name, cookieoption);
            HttpContext.Response.Cookies.Append("Id", Product.productId.ToString(), cookieoption);
            HttpContext.Response.Cookies.Append("Price", Product.price.ToString(), cookieoption);


        }
    }
}
