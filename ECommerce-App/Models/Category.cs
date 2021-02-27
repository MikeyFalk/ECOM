using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce_App.Models
{
    public class Category
    {
        [Required]
        public int Id { get; set; }
        public string Name { get; set; }
        public string MealName { get; set; }
        public string Type { get; set; }

        public List<CartItem> ListOfMeals { get; set; }


    }
}
