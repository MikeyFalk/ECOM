using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce_App.Models
{
    public class Category
    {
        public string Name { get; set; }
        public string MealName { get; set; }
        public string Type { get; set; }

        public List<MealsByCategory> ListOfMeals { get; set; }


    }
}
