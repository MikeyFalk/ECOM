using ECommerce_App.Auth.Services.Interfaces;
using ECommerce_App.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce_App.Controllers
{
    public class MealController : Controller
    {
    private readonly IMeal _meal;


    public MealController(IMeal meal)
    {
      _meal = meal; 
    }
    //public async Task<IActionResult> Index()
    //{
    //  return View();
    //}


    [AllowAnonymous]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Meal>>> GetMeals()
    {
      return Ok(await _meal.GetMeals());
    }

    [AllowAnonymous]
    [HttpGet("{id}")]
    public async Task<ActionResult<Meal>> GetMeal(int id)
    {
      Meal meal = await _meal.GetMeal(id);

      return meal;
    }

    [Authorize(Roles = "editor")]
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateMeal(int id, Meal meal)
    {
      if (id != meal.id)
      {
        return BadRequest();
      }

      var upDatedMeal = await _meal.UpdateMeal(meal);

      return Ok(upDatedMeal);
    }
    public IActionResult CreateMeal()
    {
      return View();
    }

    // [Authorize(Roles = "administrator")]
    [HttpPost]
    public async Task<ActionResult<Meal>> CreateMeal(Meal meal)
    {

      await _meal.CreateMeal(meal);
      if(!ModelState.IsValid)
      {
      return CreatedAtAction("GetMeal", new { id = meal.id }, meal);
      }
      return View(meal);
    }

    [Authorize(Roles = "Administrator")]
    [HttpDelete("{id}")]
    public async Task<ActionResult<Meal>> DeleteMeal(int id)
    {
      await _meal.DeleteMeal(id);

      return NoContent();
    }
  }
}
