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
    /// <summary>
    /// linq statement to pull the user id, to be able to pull down the cart (created when user is created)
    /// </summary>
    /// <param name="userId"></param>
    /// <returns>Cart items associated with the users cart that was created</returns>
    public async Task<List<CartItem>> GetCartItems(string userId)
    {
           var checkOut = await _context.CreateCart
                    .Where(s => s.UserId == userId)
                   .Include(d => d.CartItem)
                   .ThenInclude(m => m.Meal)
                   .FirstOrDefaultAsync();
            return (checkOut.CartItem);            
      
    }

    public async Task<CartItem> AddItemToCart(int mealId, int price, int quantity, int createCartId) 
    {
      CartItem cartItem = new CartItem()
      {
       
        MealId = mealId,
        Price = price,
        Quantity = quantity,
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

      
        /// <summary>
        /// Gets ONE specific cart, in this case the one that is attached to the userId.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>One specific cart by id</returns>
        public async Task<CreateCart> GetOne(string userId)
        {
            return await _context.CreateCart
                .FirstOrDefaultAsync(s => s.UserId == userId);
        }
    }
}
