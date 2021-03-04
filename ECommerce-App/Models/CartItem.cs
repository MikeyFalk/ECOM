using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce_App.Models
{
  public class CartItem 
  {
   public int CreateCartId { get; set; }
    
   public int MealId { get; set; }
   public int Price { get; set; }
   public int Quantity { get; set; }
    public CreateCart CreateCart { get; set; }

    public Meal Meal { get; set; }
  }
}
