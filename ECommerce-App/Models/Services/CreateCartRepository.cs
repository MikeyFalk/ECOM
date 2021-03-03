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
  public class CreateCartRepository : ICart
  {

    private readonly MjDbContext _context;

    public CreateCartRepository(MjDbContext context)
    {
      _context = context;
    }
    public async Task<CreateCart> Create(CreateCart cart)
    {
      CreateCart newCart = new CreateCart()
      {
        UserId = cart.UserId
      };

      _context.Entry(newCart).State = EntityState.Added;
      await _context.SaveChangesAsync();
      return newCart;
    }
    public async Task<List<CartItem>> GetCartItems(int CreateCartId)
    {
      return await _context.CreateCart
                        .Include(c => c.CartItem)
                        .Where(a => a.Id == CreateCartId)


                     .Where(c => c.Id == CreateCartId)
                  .ToListAsync();


      ToListAsync(s => s.Id == CreateCartId);
     
    }

    public async Task<CartItem> AddItemToCart(int mealId, int price, int createCartId) 
    {
      CartItem cartItem = new CartItem()
      {
       
        MealId = mealId,
        Price = price,
        CreateCartId = createCartId,
        
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
                .FirstOrDefaultAsync(s => s.UserId == userId);
        }
    }
}
