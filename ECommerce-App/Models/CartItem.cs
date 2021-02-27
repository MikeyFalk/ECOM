using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce_App.Models
{
  public class CartItem 
  {
   public int cartId { get; set; }
    
   public int mealId { get; set; }
   public int price { get; set; }
    
    
     //navigation properties   
    public CreateCart cart { get; set; }

    public Meal meal { get; set; }
  }
}
