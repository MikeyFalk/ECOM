using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce_App.Auth.Services.Interfaces;
using ECommerce_App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerce_App.Pages.Cart
{
    public class CartModel : PageModel
    {
    
    private readonly ICart cartService;

    public List<CreateCart> Cart { get; set; }
    public CartModel(ICart service)
    {
      cartService = service;
    }
        public async Task OnGet(string name)
        {
           Cart = await cartService.GetCartItems();
        }
    }
}
