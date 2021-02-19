using ECommerce_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce_App.Auth.Services.Interfaces
{
    public interface IMeal
    {
        Task<Meal> CreateMeal(Meal meal);

        Task<Meal> GetMeal(int id);
        Task<List<Meal>> GetMeal();
        Task<Meal> UpdateMeal(Meal meal);
        Task DeleteMeal(int id);
        Task AddMeal(int id, string name, int price, string ingredients, string nutrition, string type);
    }
}
