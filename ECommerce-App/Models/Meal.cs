using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce_App.Models
{
    public class Meal
    {   [Required]
        public int Id { get; set; }
        public string name { get; set; }
        public int price { get; set; }
        public string ingredients { get; set; }

        public string nutrition { get; set; }
        public string type { get; set; }

        public CartItem cartItem { get; set; }
    }
}
