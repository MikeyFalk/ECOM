using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce_App.Models
{
    public class Meal
    {  
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Ingredients { get; set; }

        public string Nutrition { get; set; }
        public string Type { get; set; }

        // navigation property
        public CartItem CartItem { get; set; }
    }
}
