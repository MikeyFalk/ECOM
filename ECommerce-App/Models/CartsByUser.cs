using ECommerce_App.Auth.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce_App.Models
{
  public class CartsByUser
  {
    public int CartId { get; set; }
    public int UserId { get; set; }
    public CreateCart cartId { get; set; }
    public UserDTO userId { get; set; }
    public Meal productId { get; set; }
  }
}
