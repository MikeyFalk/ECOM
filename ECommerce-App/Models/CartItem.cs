using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce_App.Models
{
  public class CartItem 
  {
    public int cartId { get; set; }
    public int productId { get; set; }
    public int price { get; set; }
  }
}
