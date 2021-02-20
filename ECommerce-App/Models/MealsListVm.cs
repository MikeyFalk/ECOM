using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce_App.Models
{
    public class MealsListVm
    {
        public List<Meal> ListOfMeals { get; set; }
       
        public Meal Id { get; set; }
        public Meal Name { get; set; }

        public Meal Ingredients { get; set; }

        public Meal Price { get; set; }

        public Meal Nutrition { get; set; }

        public Meal Type { get; set; }

        public Category Category { get; set; }
        
       
    }
}
