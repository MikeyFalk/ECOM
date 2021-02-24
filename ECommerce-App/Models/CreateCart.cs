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
    public int cartId { get; set; }
    public int price { get; set; }
    public int quantity { get; set; }
    public Meal productId { get; set; }
    public UserDTO userId { get; set; }

  }
}
