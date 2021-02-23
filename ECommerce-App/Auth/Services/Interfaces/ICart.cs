using ECommerce_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce_App.Auth.Services.Interfaces
{
  public interface ICart
  {
    Task<CreateCart> AddItemToCart(CreateCart cart);

    Task<CreateCart> GetCartItem(int id);
    Task<List<CreateCart>> GetCartItems();
    Task<CreateCart> UpdateQuantity(CreateCart cart);
    Task DeleteFromCart(int id);

  }
}
