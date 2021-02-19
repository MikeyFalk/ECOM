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
        public int id { get; set; }
        public string name { get; set; }
        public string mealName { get; set; }
        public string type { get; set; }

        public List<MealsByCategory> ListOfMeals { get; set; }


    }
}
