using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce_App.Auth.Services.Interfaces;
using ECommerce_App.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerce_App.Pages.Products
{
    public class ProductsModel : PageModel
    {
    public List<Meal> Products { get; set; }

    private readonly IMeal mealsService;

    public ProductsModel(IMeal service)
    {
      mealsService = service;
    }
    [AllowAnonymous]
    public async Task OnGet(string name)
    {
      Products = await mealsService.GetMeals();
    }
  }
}
