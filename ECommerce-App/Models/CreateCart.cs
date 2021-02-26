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
    [Required]
    public int Id { get; set; }
    public int price { get; set; }
    public int quantity { get; set; }
    public string userId { get; set; }
    public List<CartItem> cartItem { get; set; }

  }
}
