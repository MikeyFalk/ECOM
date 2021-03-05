using ECommerce_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce_App.Auth.Services.Interfaces
{
    public interface ICategory
    {
        
        Task<Category> CreateCategory(Category category);

        Task<Category> GetCategory(int id);
        Task<List<Category>> GetCategories();
        Task<Category> UpdateCategory(Category category);
        Task DeleteCategory(int id);
    }
}
