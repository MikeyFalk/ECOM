using ECommerce_App.Auth.Models;
using ECommerce_App.Auth.Models.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce_App.Models
{
  public class CreateCart
  {
    
    public int Id { get; set; }
    public int Price { get; set; }
    public int Quantity { get; set; }
    public string UserId { get; set; }
    public List<CartItem> CartItem { get; set; }

  }
}
