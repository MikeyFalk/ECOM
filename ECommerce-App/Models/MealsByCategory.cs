using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce_App.Models
{
    public class MealsByCategory
    {
        public int CategoryId { get; set; }
        public int MealId { get; set; }

        
        //navigation properties
        public Meal meal { get; set; }
        public Category category { get; set; }
    }
}
