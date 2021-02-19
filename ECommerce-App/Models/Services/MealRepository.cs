using ECommerce_App.Auth.Services.Interfaces;
using ECommerce_App.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce_App.Models.Services
{
    public class MealRepository : IMeal
    {
        private readonly MjDbContext _context;

        public MealRepository(MjDbContext context)
        {
            _context = context;
        }

        public async Task AddMeal(int id, string name, int price, string ingredients, string nutrition, string type)
        {
            Meal meal = new Meal
            {
                id = id,
                name = name,
                price = price,
                ingredients = ingredients,
                nutrition = nutrition,
                type = type

            };

            _context.Entry(meal).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            await _context.SaveChangesAsync();

        }

        public async Task<Meal> CreateMeal(Meal meal)
        {
            _context.Entry(meal).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            await _context.SaveChangesAsync();

            return meal;
        }

        public async Task DeleteMeal(int id)
        {
            Meal meal = await GetMeal(id);
            _context.Entry(meal).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<Meal> GetMeal(int id)
        {
            Meal meal = await _context.Meal.FindAsync(id);
            return meal;
        }

        public async Task<List<Meal>> GetMeals()
        {
            var meals = await _context.Meal.ToListAsync();
            return meals;
        }

        public async Task<Meal> UpdateMeal(Meal meal)
        {
            _context.Entry(meal).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return meal;
        }
    }

}

