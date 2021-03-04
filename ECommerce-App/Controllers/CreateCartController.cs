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
  public class CreateCartController : Controller
  {
    private readonly ICart _cart;


    public CreateCartController(ICart cart)
    {
      _cart = cart;
    }
    public IActionResult Index()
    {
      return View();
    }
    [HttpPost]
    public async Task<ActionResult<CreateCart>> Create(CreateCart cart) 
      {
           await _cart.Create(cart);
           return CreatedAtAction("GetCartItems", new { id = cart.Id}, cart);
      }

    [HttpGet]
    public async Task<ActionResult<List<CartItem>>> GetCartItems(string userId)
    {
      return await _cart.GetCartItems(userId);
    }

    [HttpPut("{createCartId}")]
    public async Task<ActionResult> AddItemToCart(int mealId, int price, int quantity, int createCartId)
    {
      await _cart.AddItemToCart(mealId, price, quantity, createCartId);
      return RedirectToPage("/cart");
    }

    [HttpGet("{userId}")]
    public async Task<ActionResult<CreateCart>> GetCart(string userId)
    {
       CreateCart Cart = await _cart.GetOne(userId);
       return Cart;
    }

    }
}
