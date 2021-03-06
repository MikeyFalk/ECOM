using ECommerce_App.Auth.Services.Interfaces;
using ECommerce_App.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce_App.Models.Services
{
    public class CategoryRepository : ICategory
    {
        private readonly MjDbContext _context;

        public CategoryRepository(MjDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Async method to create a category, that is used from the controller 
        /// </summary>
        /// <param name="category"></param>
        /// <returns>a new category on the categories page</returns>
        public async Task<Category> CreateCategory(Category category)
        {
            _context.Entry(category).State = EntityState.Added;
            await _context.SaveChangesAsync();

            return category;
        }

        public async Task DeleteCategory(int id)
        {
            Category category = await GetCategory(id);
            _context.Entry(category).State = EntityState.Deleted;
            await _context.SaveChangesAsync();       
        }

        public async Task<Category> GetCategory(int id)
        {
            Category category = await _context.Category.FindAsync(id);
            return category;
        }

        public async Task<List<Category>> GetCategories()
        {
            var categories = await _context.Category.ToListAsync();
            return categories;
        }

        public async Task<Category> UpdateCategory(Category category)
        {
            _context.Entry(category).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return category;
        }
    }
}
