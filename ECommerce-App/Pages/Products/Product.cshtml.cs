using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce_App.Auth.Services.Interfaces;
using ECommerce_App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerce_App.Pages.Products
{
    public class ProductModel : PageModel
    {
    public string id;
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
    }
}
