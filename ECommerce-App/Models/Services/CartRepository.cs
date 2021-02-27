using ECommerce_App.Auth.Services.Interfaces;
using ECommerce_App.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce_App.Models.Services
{
  public class CartRepository : ICart
  {

    private readonly MjDbContext _context;

    public CartRepository(MjDbContext context)
    {
      _context = context;
    }
    public async Task<CreateCart> Create(CreateCart cart)
    {
      CreateCart newCart = new CreateCart()
      {
        userId = cart.userId
      };

      _context.Entry(newCart).State = EntityState.Added;
      await _context.SaveChangesAsync();
      return newCart;
    }
    public async Task<CreateCart> GetCartItems(int id)
    {
      CreateCart cart = await _context.CreateCart.FindAsync(id);
      return cart;
    }

    public async Task<CartItem> AddItemToCart(int mealId, int price, int cartId) 
    {
      CartItem cartItem = new CartItem()
      {
       
        mealId = mealId,
        price = price,
       
        cartId = cartId
      };
      _context.Entry(cartItem).State = EntityState.Added;
      await _context.SaveChangesAsync();
      return cartItem;
    }

    public Task DeleteFromCart(int id)
    {
      throw new NotImplementedException();
    }


    public Task<CreateCart> UpdateQuantity(CreateCart cart)
    {
      throw new NotImplementedException();
    }

      
        
        public async Task<CreateCart> GetOne(string userId)
        {
            return await _context.CreateCart
              // .Include(u => u.userId)
                .FirstOrDefaultAsync(s => s.userId == userId);
        }
    }
}
