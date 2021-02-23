using ECommerce_App.Auth.Services.Interfaces;
using ECommerce_App.Data;
using ECommerce_App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce_App.Controllers
{
  public class CartController : Controller
  {
    private readonly ICart _cart;


    public CartController(ICart cart)
    {
      _cart = cart;
    }
    public IActionResult Index()
    {
      return View();
    }
    public async Task<ActionResult<CreateCart>> AddItemToCart(CreateCart cart)
    {
      //_cart.Entry(cart).State = EntityState.Added;
      //await _cart.SaveChangesAsync();
      return cart;
    }

    //Task<Cart> GetCartItem(int id);
    //Task<List<Cart>> GetCartItems();
    //Task<Cart> UpdateQuantity(Cart cart);
    //Task DeleteFromCart(int id);
  }
}
