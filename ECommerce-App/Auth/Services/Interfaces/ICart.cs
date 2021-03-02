using ECommerce_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce_App.Auth.Services.Interfaces
{
  public interface ICart
  {
    Task<CreateCart> Create(CreateCart cart);
    Task<CartItem> AddItemToCart(int mealId, int price, int createCartId);

    Task<List<CartItem>> GetCartItems(int CreateCartId);
    Task<CreateCart> UpdateQuantity(CreateCart cart);
    Task DeleteFromCart(int id);

   Task<CreateCart> GetOne(string userId);

  }
}
