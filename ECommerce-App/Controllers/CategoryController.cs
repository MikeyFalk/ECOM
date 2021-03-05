using ECommerce_App.Auth.Services.Interfaces;
using ECommerce_App.Data;
using ECommerce_App.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce_App.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategory _category;

        // sets up reference to our db 
        public CategoryController(ICategory category)
        {
            _category = category;
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}
        /// <summary>
        /// Gets all categories available from the db 
        /// </summary>
        /// <returns>Categories</returns>
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
        {
            return Ok(await _category.GetCategories());
        }

        /// <summary>
        /// Pulls one specific id from the db 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>The category that matches the id inputted</returns>
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategory(int id)
        {
            Category category = await _category.GetCategory(id);

            return category;
        }

        /// <summary>
        /// With the correct permissions, you are allowed to update a category that is within the db 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="category"></param>
        /// <returns>Update by id that matches the category the admin/editor would like to update</returns>
        [Authorize(Roles = "editor")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, Category category)
        {
            if (id != category.Id)
            {
                return BadRequest();
            }

            var upDatedCategory = await _category.UpdateCategory(category);

            return Ok(upDatedCategory);
        }

        /// <summary>
        /// Below we can create a new category, with the authorized role. 
        /// </summary>
        /// <param name="category"></param>
        /// <returns>A new category</returns>
        // [Authorize(Roles = "administrator")]
        [HttpPost]
        public async Task<ActionResult<Category>> CreateCategory(Category category)
        {

            await _category.CreateCategory(category);

            return CreatedAtAction("GetCategory", new { id = category.Id }, category);
        }

       
        [Authorize(Roles = "Administrator")]
        [HttpDelete("{id}")]
        public async Task<ActionResult<Category>> DeleteCategory(int id)
        {
            await _category.DeleteCategory(id);

            return NoContent();
        }
    }
}
