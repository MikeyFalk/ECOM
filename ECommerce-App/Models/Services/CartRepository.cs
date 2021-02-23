using ECommerce_App.Auth.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce_App.Models.Services
{
  public class CartRepository : ICart
  {
    public Task<CreateCart> AddItemToCart(CreateCart cart)
    {
      throw new NotImplementedException();
    }

    public Task DeleteFromCart(int id)
    {
      throw new NotImplementedException();
    }

    public Task<CreateCart> GetCartItem(int id)
    {
      throw new NotImplementedException();
    }

    public Task<List<CreateCart>> GetCartItems()
    {
      throw new NotImplementedException();
    }

    public Task<CreateCart> UpdateQuantity(CreateCart cart)
    {
      throw new NotImplementedException();
    }
  }
}
